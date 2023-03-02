using BusinessLogicLayer.Models;
using BusinessLogicLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class HRController : Controller
    {
        private readonly IHRRepo _repo;
        private readonly ILogger<HRController> _logger;

        public HRController(IHRRepo repo, ILogger<HRController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost("HR")]
        public async Task<HRModel> AddHR(HRModel hRModel)
        { 

            var hRModeldata = await _repo.AddHR(hRModel);
            if(hRModeldata == null)
            {
                return null;
            }
            return hRModeldata;
        }

        [HttpPost("Jobs")]
        public async Task<JobsModel> AddJobs(JobsModel jobsModel)
        {
            var jobs = await _repo.AddJobs(jobsModel);
            if(jobs == null)
            {
                return null;
            }
            return jobs;
        }

        [HttpGet("GetJobs/{UserName}")]
        public async Task<List<JobsModel>> GetJobs(string UserName)
        { 
            var jobs = await _repo.GetJobs(UserName);
            if(jobs == null)
            {
                return null;
            }
            return jobs;
        }


        [HttpGet("ViewJobSkills/{Id}")]
        public async Task<string[]> ViewJobSkills(int Id)
        {
            var skills = await _repo.ViewJobSkills(Id);
            if (skills == null)
            {
                return null;
            }
            return skills;
        } 


        [HttpGet("GetHr/{UserName}")]
        public async Task<HRModel> GetHr(string UserName)
        {
            var HR = await _repo.GetHr(UserName);
            if(HR == null)
            {
                return null;
            }
            return HR;
        }

        [HttpGet("getJobsById/{Id}")]
        public async Task<JobsModel> GetJobsById(int Id)
        {
            var jobsModel = await _repo.GetJobsById(Id);
            if (jobsModel == null)
            {
                return null;
            }
            return jobsModel;
        }

        [HttpGet("HRNoti")]
        public async Task<List<HRNotiModel>> HRNoti()
        {
            string email = "";
            var list = new List<object>();
            foreach (var claim in User.Claims)
            {
                list.Add(claim.Value);
            }
            var userName = list[0];
            email = userName.ToString();
            var notifications = await _repo.HRNoti(email);
            if(notifications == null)
            {
                return null;
            }
            return notifications;
        }

        [HttpGet("CandidateDetails/{Id}/{JobsId}")]
        public async Task<AllCandidateDetailsModel> CandidateDetails(int Id,int JobsId)
        {
            var details = await _repo.CandidateDetails(Id, JobsId);
            if (details == null)
            {
                return null;
            }
            return details;
        }

        [HttpGet("ViewSkills/{Id}")]
        public async Task<List<SkillsModel>> ViewSkills(int Id)
        {
            var listOfSkills = await _repo.ViewSkills(Id);
            if (listOfSkills == null)
            {
                return null;
            }
            return listOfSkills;
        }

        [HttpGet("ViewResume/{Id}")]
        public async Task<FilesModel> ViewResume(int Id)
        {
            var resume = await _repo.GetResume(Id);
            if (resume == null)
            {
                return null;
            }
            return resume;
        }

        [HttpGet("selected")]
        public async Task<List<SelectedModel>> Selected()
        {
            string email = "";
            var list = new List<object>();
            foreach (var claim in User.Claims)
            {
                list.Add(claim.Value);
            }
            var userName = list[0];
            email = userName.ToString();
            var selected = await _repo.Selected(email);
            if (selected == null)
            {
                return null;
            }
            return selected;
        }

        [HttpPut("Accept/{Id}")]
        public async Task<JobStatusModel> Accept(int Id)
        {
            var status = await _repo.Accept(Id);
            if(status == null)
            {
                return null;
            }
            return status;
        }

        [HttpPut("Reject/{Id}")]
        public async Task<JobStatusModel> Reject(int Id)
        {
            var status = await _repo.Reject(Id);
            if (status == null)
            {
                return null;
            }
            return status;
        }


        [HttpPut("EditHr")]
        public async Task<HRModel> EditHr(HRModel hRModel)
        {
            var HR = await _repo.EditHr(hRModel);
            if (HR == null)
            {
                return null;
            }
            return HR;
        }

        [HttpPut("EditJobs")]
        public async Task<JobsModel> EditJobs(JobsModel jobsModel)
        {
            var jobs = await _repo.EditJobs(jobsModel);
            if (jobs == null)
            {
                return null;
            }
            return jobs;
        }

        [HttpDelete("DeleteJob/{Id}")]
        public async Task<string> DeleteJob(int Id)
        {
            var deleteJob = await _repo.DeleteJob(Id);
            if (deleteJob == null)
            {
                return "delete unsuccessfull";
            }
            return deleteJob;

        }
    }
}
