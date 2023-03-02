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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class JobsController : Controller
    {
        private readonly ICandidateRepo _repo;
        private readonly ILogger<JobsController> _logger;
        public JobsController(ICandidateRepo repo, ILogger<JobsController> logger)
        {
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("GetAllJobs/{Id}")]
        public async Task<List<AllJobsModel>> GetAllJobs(int Id,bool isLogged=false, string userEmail = null)
        {
            string email = "";
            if (!isLogged)
            { 
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
            }
            else
            {
                email = userEmail;
            }
            var jobs = await _repo.GetAllJobs(email,Id);             
            if (jobs == null)
            {
                return null;
            }
            return jobs;
        }

        [HttpGet("GetAllJobsById/{Id}")]
        public async Task<AllJobsModel> GetAllJobsById(int Id)
        {
            var Jobs = await _repo.GetAllJobsById(Id);
            if (Jobs == null)
            {
                return null;
            }
            return Jobs;
        }
        [HttpGet("getcount")]
        public async Task<int> getcount()
        {
            string email = "";
            var list = new List<object>();
            foreach (var claim in User.Claims)
            {
                list.Add(claim.Value);
            }
            var userName = list[0];
            email = userName.ToString();
            
            var count = await _repo.getcount(email);
            return count;
        }

        [HttpGet("JobsApplied")]
        public async Task<List<JobStatusModel>> JobsApplied(bool isLogged = false, string userEmail = null)
        {
            string email = "";
            if (!isLogged)
            {
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
            }
            else
            {
                email = userEmail;
            }
            var applied = await _repo.JobsApplied(email);
            if (applied == null)
            {
                return null;
            }
            return applied;
        }

        [HttpGet("Search/{value}")]
        public async Task<List<AllJobsModel>> Search(string value)
        {
            string email = "";
            var list = new List<object>();
            foreach (var claim in User.Claims)
            {
                list.Add(claim.Value);
            }
            var userName = list[0];
            email = userName.ToString();
            var jobs = await _repo.Search(email, value);
            if (jobs == null)
            {
                return null;
            }
            return jobs;
        }

        [HttpPost("Apply/{Id}")]
        public async Task<string> Apply(int Id)
        {
            string email = "";
            var list = new List<object>();
            foreach (var claim in User.Claims)
            {
                list.Add(claim.Value);
            }
            var userName = list[0];
            email = userName.ToString();
            var apply = await _repo.Apply(Id, email);
            if (apply == null)
            {
                return null;
            }
            return apply;
        }
    }
}
