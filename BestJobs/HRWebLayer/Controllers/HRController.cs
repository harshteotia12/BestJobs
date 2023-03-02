using HRWebLayer.Helper;
using HRWebLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRWebLayer.Controllers
{
    [CustomAuthorization]
    public class HRController : Controller
    {
        private readonly ILogger<HRController> _logger;
        private readonly IAPI _APIUrl;

        public HRController(ILogger<HRController> logger,IAPI APIUrl)
        {
            _APIUrl = APIUrl;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<JobsModel> jobs = new List<JobsModel>();
            var userName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/Hr/GetJobs/{userName}");
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                jobs = JsonConvert.DeserializeObject<List<JobsModel>>(result);
            }
            return View(jobs);
        }

        public async Task<IActionResult> HRDetails()
        {
            HRModel hRModel = new HRModel();
            var userName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/Hr/GetHR/{userName}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                hRModel = JsonConvert.DeserializeObject<HRModel>(result);
            }
            return View(hRModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            HRModel hRModel;
            var userName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/Hr/GetHR/{userName}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                hRModel = JsonConvert.DeserializeObject<HRModel>(result);
                if(hRModel.HRId != 0)
                {
                    return RedirectToAction("HRDetails","HR");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HRId,HRName,HRYOE,Orgname")] HRModel hRModel, List<IFormFile> image1)
        {
            foreach (var item in image1)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        hRModel.OrgPhoto = stream.ToArray();
                    }
                }
            }
            hRModel.UserName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await client.PostAsync("api/HR/HR", new StringContent(JsonConvert.SerializeObject(hRModel), Encoding.UTF8, "application/json"));
            _logger.LogInformation("In Online News Paper Web Application News Category Controller, Exiting from Create Method after Successfully Binding");
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit()
        {
            HRModel hRModel = new HRModel();
            var userName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/Hr/GetHR/{userName}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                hRModel = JsonConvert.DeserializeObject<HRModel>(result);
            }
            return View(hRModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("HRId,HRName,HRYOE,UserName,Orgname,OrgPhoto")] HRModel hRModel)
        {
            hRModel.UserName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await client.PutAsync("api/HR/EditHr", new StringContent(JsonConvert.SerializeObject(hRModel), Encoding.UTF8, "application/json"));
            _logger.LogInformation("In Online News Paper Web Application News Category Controller, Exiting from Create Method after Successfully Binding");
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> CreateJobs()
        {
            bool isHrRegistered = false;
            HRModel hRModel;
            var userName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/Hr/GetHR/{userName}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                hRModel = JsonConvert.DeserializeObject<HRModel>(result);
                if(hRModel.HRId != 0)
                {
                    isHrRegistered = true;  
                }
            }
            ViewBag.IsHrRegistered = isHrRegistered;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJobs([Bind("JobsId,HRId,JobsName,JobsSkill,JobsPackage,JobsPostDate,JobsDescription")] JobsModel jobsModel)
        {

            jobsModel.UserName = HttpContext.Session.GetString("UserName");
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await client.PostAsync("api/HR/jobs", new StringContent(JsonConvert.SerializeObject(jobsModel), Encoding.UTF8, "application/json"));
            _logger.LogInformation("In Online News Paper Web Application News Category Controller, Exiting from Create Method after Successfully Binding");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteJobs(int Id)
        {
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await client.DeleteAsync($"api/hr/DeleteJob/{Id}");
            return RedirectToAction("Index", "HR");
        }

        public async Task<IActionResult> EditJobs(int Id)
        {
            HttpClient client = _APIUrl.Initial();
            JobsModel jobsModel = new JobsModel();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/hr/getJobsByid/{Id}");
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                jobsModel = JsonConvert.DeserializeObject<JobsModel>(result);
            }
            return View(jobsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditJobs([Bind("JobsId,HRId,JobsName,JobsSkill,JobsPackage,JobsPostDate,JobsDescription")] JobsModel jobsModel)
        {
            jobsModel.JobsPostDate = DateTime.Now;
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            await client.PutAsync($"api/HR/editjobs", new StringContent(JsonConvert.SerializeObject(jobsModel), Encoding.UTF8, "application/json"));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> HRNoti()
        {
            bool isAvailable = false;
            HttpClient client = _APIUrl.Initial();
            List<HRNotiModel> hRNoti = new List<HRNotiModel>();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/HR/HRNoti");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                hRNoti = JsonConvert.DeserializeObject<List<HRNotiModel>>(result); 
                if (hRNoti.Count != 0)
                {
                    isAvailable = true;
                }
            }
            ViewBag.isAvailable = isAvailable;
            return View(hRNoti);
        }

        public async Task<ActionResult> CandidateDetails(int Id, [Bind("JobsId")] JobsIdMode jobsIdMode)
        {
            HttpClient client = _APIUrl.Initial();
            AllCandidateDetailsModel details = new AllCandidateDetailsModel();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/HR/CandidateDetails/{Id}/{jobsIdMode.JobsId}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                details = JsonConvert.DeserializeObject<AllCandidateDetailsModel>(result);
            }
            ViewBag.JobsId = jobsIdMode.JobsId; 
            return View(details);
        }

        public async Task<ActionResult> ViewSkills(int Id,int JobsId)
        {
            int totalSkills = 0;
            int gotSkills = 0;
            HttpClient client = _APIUrl.Initial();
            List<SkillsModel> skillsModel = new List<SkillsModel>();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var response = await client.GetAsync($"api/HR/ViewSkills/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                skillsModel = JsonConvert.DeserializeObject<List<SkillsModel>>(result);
            }

            var JwtToken1 = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
            var response1 = await client.GetAsync($"api/HR/ViewJobSkills/{JobsId}");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                var skills = JsonConvert.DeserializeObject<string[]>(result);
                totalSkills= skills.Count();
                ViewBag.TotalSkills = totalSkills;
                foreach(var item in skillsModel)
                {
                    foreach(var item2 in skills)
                    {
                        if(item.SkillName.Equals(item2))
                        {
                            item.Matched = true;
                            gotSkills++;
                        }
                    }
                }
            }
            ViewBag.GotSkills=gotSkills;
            return View(skillsModel);
        }

        public async Task<IActionResult> ViewResume(int Id)
        {
            try
            {
                _logger.LogInformation("User Viewing Resume");
                FilesModel files = new FilesModel();
                HttpClient client = _APIUrl.Initial();
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await client.GetAsync($"api/HR/ViewResume/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    files = JsonConvert.DeserializeObject<FilesModel>(result);
                    if (files == null)
                    {
                        return RedirectToAction("Index", "Resume");
                    }
                }
                return File(files.DataFiles, "application/pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        public async Task<ActionResult> Accept(int Id)
        {
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var insert = await client.PutAsync($"api/HR/Accept/{Id}", new StringContent(JsonConvert.SerializeObject(Id), Encoding.UTF8, "application/json"));
            if(insert.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "HR");
            }
            return RedirectToAction("CandidateDetails", "HR");
        }

        public async Task<ActionResult> Reject(int Id)
        {
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            var insert = await client.PutAsync($"api/HR/Reject/{Id}", new StringContent(JsonConvert.SerializeObject(Id), Encoding.UTF8, "application/json"));
            if (insert.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "HR");
            }
            return RedirectToAction("CandidateDetails", "HR");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Selected()
        {
            bool isAvailable = false;
            List<SelectedModel> selectedModel = new List<SelectedModel>();
            HttpClient client = _APIUrl.Initial();
            var JwtToken = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
            HttpResponseMessage response = await client.GetAsync("api/hr/selected");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                selectedModel = JsonConvert.DeserializeObject<List<SelectedModel>>(result);
                if(selectedModel.Count != 0)
                {
                    isAvailable = true;
                }
            }
            ViewBag.isAvailable = isAvailable;
            return View(selectedModel);
        }
    }
}
