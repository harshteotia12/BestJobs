using CandidateWebLayer.Helper;
using CandidateWebLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static CandidateWebLayer.Helper.ExceptionLogFilterNewAttribute;

namespace CandidateWebLayer.Controllers
{
    [CustomAuthorization]
    [ExceptionLogFilterNew]
    //[System.Web.Mvc.HandleError]
    public class CandidateController : Controller
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly HttpClient Client;
        public CandidateController(ILogger<CandidateController> logger, IAPI _APIUrl)
        {
            Client = _APIUrl.Initial();
            _logger = logger;
            
        }

        public async Task<ActionResult> Index(int pg = 1)
        {
            bool isSelected = false;
            string jobsName = "";
            int jobsId = 0;
            
            var JwtToken1 = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
            HttpResponseMessage response1 = await Client.GetAsync("api/Jobs/JobsApplied");
            List<JobStatusModel> jobsAppliedList = new List<JobStatusModel>();
            if (response1.IsSuccessStatusCode)
            {
                var result1 = response1.Content.ReadAsStringAsync().Result;
                jobsAppliedList = JsonConvert.DeserializeObject<List<JobStatusModel>>(result1);
            }
            foreach(var job in jobsAppliedList)
            {
                if(job.IsSelected)
                {
                    isSelected = true;
                    jobsName = job.JobsName;
                    jobsId = job.JobsId;    
                }
            }
            ViewBag.jobsId = jobsId;
            ViewBag.IsSelected = isSelected;
            ViewBag.JobName = jobsName;
            if (!isSelected)
            {
                List<AllJobsModel> jobs = new List<AllJobsModel>();
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                var response = await Client.GetAsync($"api/jobs/getalljobs/{pg}");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    jobs = JsonConvert.DeserializeObject<List<AllJobsModel>>(result);
                }
                int count = 0;
                var JwtToken2 = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken2);
                var response2 = await Client.GetAsync("api/jobs/getcount");
                
                if (response2.IsSuccessStatusCode)
                {
                    var result = response2.Content.ReadAsStringAsync().Result;
                    count = JsonConvert.DeserializeObject<int>(result);
                }
                const int pageSize = 3;
                if (pg < 1)
                {
                    pg = 1;
                }
                int recsCount = count;
                var pager = new Pager(recsCount, pg, pageSize);
                this.ViewBag.Pager = pager;
                return View(jobs);
            }
            return View();
        }
        
        public async Task<ActionResult> CreateDetails()
        {
            try
            {
                _logger.LogInformation("Create Details called");
                CandidateDetailsModel candDetails;
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetDetailsById");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    candDetails = JsonConvert.DeserializeObject<CandidateDetailsModel>(result);
                    if (candDetails != null)
                    {
                        return RedirectToAction("CreateDetailsView", "Candidate");
                    }
                }
                else
                {
                    ErrorPageController.statuscode = (int)response.StatusCode;
                    return RedirectToAction("ErrorPage", "ErrorPage");
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDetails([Bind("CandidateDetailsId,Email,FirstName,LastName,DOB,Phone,AddLine,City,Country")] CandidateDetailsModel candidateDetailsModel)
        {
            try
            {
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                var insert = await Client.PostAsync("api/candidate/candidatedetails", new StringContent(JsonConvert.SerializeObject(candidateDetailsModel), Encoding.UTF8, "application/json"));
                if (insert.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"user {candidateDetailsModel.FirstName} has successfully filled his details");
                    HttpContext.Session.SetString("YourName", candidateDetailsModel.FirstName);
                }
                else
                {
                    ErrorPageController.statuscode = (int)insert.StatusCode;
                    return RedirectToAction("ErrorPage", "ErrorPage");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        public async Task<ActionResult> EditDetails()
        {
            try
            {
                _logger.LogInformation("Edit Details called");
                CandidateDetailsModel candDetails;
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetDetailsById");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    candDetails = JsonConvert.DeserializeObject<CandidateDetailsModel>(result);
                }
                else
                {
                    ErrorPageController.statuscode = (int)response.StatusCode;
                    return RedirectToAction("ErrorPage", "ErrorPage");
                }
                return View(candDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDetails([Bind("CandidateDetailsId,Email,FirstName,LastName,DOB,Phone,AddLine,City,Country")] CandidateDetailsModel candidateDetails)
        {
            try
            {

                if (candidateDetails.CandidateDetailsId == 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        
                        var JwtToken = HttpContext.Session.GetString("JwtToken");
                        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                        var insert = await Client.PutAsync("api/Candidate/UpdateDetails", new StringContent(JsonConvert.SerializeObject(candidateDetails), Encoding.UTF8, "application/json"));
                        if (insert.IsSuccessStatusCode)
                        {
                            _logger.LogInformation($"{candidateDetails.FirstName} has successfully edited his details");
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"error => {ex.Message}");
                        return null;
                    }

                }
                return View(candidateDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        public async Task<ActionResult> CreateDetailsView()
        {
            try
            {
                _logger.LogInformation("user is Viewing his details");
                CandidateDetailsModel candDetails = new CandidateDetailsModel();
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetDetailsById");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    candDetails = JsonConvert.DeserializeObject<CandidateDetailsModel>(result);
                }
                return View(candDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }


        

        public async Task<ActionResult> CreateResume()
        {
            try
            {
                _logger.LogInformation("Create Resume Method called");
                CandidateResumeModel candResume;
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetResumeById");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    candResume = JsonConvert.DeserializeObject<CandidateResumeModel>(result);
                    if (candResume != null)
                    {
                        return RedirectToAction("CreateResumeView", "Candidate");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResume([Bind("CandidateResumeId,CandidateDetailsId,TenthSchool,TenthSchoolPercentage,TwelfthSchool,TwelfthSchoolPercentage,GraduationSchool,GraduationSchoolPercentage,GraduationStream,CurrentOrganization,CurrentCTC")] CandidateResumeModel candidateResumeModel)
        {
            try
            {
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                var insert = await Client.PostAsync("api/candidate/CandidateResume", new StringContent(JsonConvert.SerializeObject(candidateResumeModel), Encoding.UTF8, "application/json"));
                if (insert.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Create Resume Bind Method called");
                    return RedirectToAction("Index", "Resume");
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        public async Task<ActionResult> EditResume()
        {
            try
            {
                _logger.LogInformation("Edit Resume Method called");
                CandidateResumeModel candResume = new CandidateResumeModel();
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetResumeById");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    candResume = JsonConvert.DeserializeObject<CandidateResumeModel>(result);
                }
                return View(candResume);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResume([Bind("CandidateResumeId,CandidateDetailsId,TenthSchool,TenthSchoolPercentage,TwelfthSchool,TwelfthSchoolPercentage,GraduationSchool,GraduationSchoolPercentage,GraduationStream,CurrentOrganization,CurrentCTC")] CandidateResumeModel candidateResume)
        {
            try
            {
                if (candidateResume.CandidateResumeId == 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        
                        var JwtToken = HttpContext.Session.GetString("JwtToken");
                        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                        await Client.PutAsync("api/Candidate/UpdateResume", new StringContent(JsonConvert.SerializeObject(candidateResume), Encoding.UTF8, "application/json"));
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"error {ex.Message}");
                    }

                }
                return View(candidateResume);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        public async Task<ActionResult> CreateResumeView()
        {
            try
            {
                _logger.LogInformation("Create Resume getDetails called");
                CandidateResumeModel candResume = new CandidateResumeModel();
                
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetResumeById");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    candResume = JsonConvert.DeserializeObject<CandidateResumeModel>(result);
                }
                List<SkillsModel> skills = new List<SkillsModel>(); 
                var JwtToken1 = HttpContext.Session.GetString("JwtToken");
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
                HttpResponseMessage response1 = await Client.GetAsync("api/Candidate/skills");
                if(response1.IsSuccessStatusCode)
                {
                    var result = response1.Content.ReadAsStringAsync().Result;
                    skills = JsonConvert.DeserializeObject<List<SkillsModel>>(result);  
                }
                ViewBag.Skill = skills;
                return View(candResume);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }
        
        public  ActionResult Skills()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Skills(SkillsListModel skillModel)
        {
            foreach(var item in skillModel.Skills)
            {
                item.UserName = HttpContext.Session.GetString("UserName");
            }
            
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await Client.PostAsync("api/candidate/skills", new StringContent(JsonConvert.SerializeObject(skillModel), Encoding.UTF8, "application/json"));
            return RedirectToAction("Index", "Candidate");
        }

        public async Task<ActionResult> JobDetail(int Id)
        {
            bool IsApplied = false;
            bool IsComplete = false;
            
            var JwtToken1 = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
            HttpResponseMessage response1 = await Client.GetAsync("api/Jobs/JobsApplied");
            if (response1.IsSuccessStatusCode)
            {
                var result1 = response1.Content.ReadAsStringAsync().Result;
                var jobsAppliedList = JsonConvert.DeserializeObject<List<JobStatusModel>>(result1);
                if (jobsAppliedList != null)
                {
                    foreach (var job in jobsAppliedList)
                    {
                        if (job.JobsId == Id)
                        {
                            IsApplied = true;
                        }
                        if(job.IsComleted)
                        {
                            IsComplete = true;  
                        }
                    }
                }
            }
            ViewBag.IsApplied = IsApplied;
            ViewBag.IsComplete = IsComplete;
            AllJobsModel jobsModel = new AllJobsModel();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            HttpResponseMessage response = await Client.GetAsync($"api/Jobs/GetAllJobsById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                jobsModel = JsonConvert.DeserializeObject<AllJobsModel>(result);
            }
            return View(jobsModel);
        }

        public async Task<ActionResult> Apply(int Id)
        {
            bool IsDetails = false;
            _logger.LogInformation("Edit Details called");
            CandidateDetailsModel candDetails;
            
            var JwtToken1 = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
            HttpResponseMessage response = await Client.GetAsync("api/Candidate/GetDetailsById");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                candDetails = JsonConvert.DeserializeObject<CandidateDetailsModel>(result);
                if(candDetails == null)
                {
                    IsDetails = true;
                }
            }
            ViewBag.IsDetails = IsDetails;
            if(IsDetails)
            {
                return View();
            }
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await Client.PostAsync($"api/Jobs/Apply/{Id}", new StringContent(Id.ToString(), Encoding.UTF8, "application/json"));
            return RedirectToAction("Index","Candidate");
        }

        public async Task<ActionResult> JobsNotification()
        {
            bool isAvailable = false;
            var JwtToken1 = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
            HttpResponseMessage response1 = await Client.GetAsync("api/Jobs/JobsApplied");
            List<JobStatusModel> jobsAppliedList = new List<JobStatusModel>();
            if (response1.IsSuccessStatusCode)
            {
                var result1 = response1.Content.ReadAsStringAsync().Result;
                jobsAppliedList = JsonConvert.DeserializeObject<List<JobStatusModel>>(result1);
                if(jobsAppliedList.Count != 0)
                {
                    isAvailable = true;
                }
            }
            ViewBag.isAvailable = isAvailable;
            return View(jobsAppliedList);
        }

        public async Task<ActionResult> Search(string value)
        {
            if(value == null)
            {
                return RedirectToAction("Index");
            }
            bool isResult = false;
            List<AllJobsModel> jobs = new List<AllJobsModel>();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await Client.GetAsync($"api/jobs/Search/{value}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                jobs = JsonConvert.DeserializeObject<List<AllJobsModel>>(result);
                if(jobs.Count != 0)
                {
                    isResult = true;
                }
            }
            ViewBag.isResult = isResult;    
            return View(jobs);
        }
        public ActionResult Error(ErrorClass errorClass)
        {
            var a = errorClass;
            ViewBag.Message = a.Message;
            return View();
        }
    }
}