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
    [ServiceExceptionInterceptor]
    public class CandidateController : Controller
    {
        private readonly ICandidateRepo _repo;
        private readonly ILogger<CandidateController> _logger;
        /// <summary>
        /// Constructor to initialize the ICategoryRepo
        /// </summary>
        /// <param name="repo"></param>
        public CandidateController(ICandidateRepo repo, ILogger<CandidateController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost("CandidateDetails")]
        public async Task<ActionResult<CandidateDetailsModel>> AddCandidateDetails(CandidateDetailsModel candidateDetailsModel)
        {
            try
            {
                _logger.LogInformation("API post for cand detatils called");
                candidateDetailsModel.Email = "Pseudo_Email_Hehe";
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                candidateDetailsModel.Email = userName.ToString();

                var candidateDetails = await _repo.AddCandidateDetails(candidateDetailsModel);
                if (candidateDetails == null)
                {
                    return BadRequest();
                }
                return candidateDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }

        }

        [HttpPost("CandidateResume")]
        public async Task<ActionResult<CandidateResumeModel>> AddCandidateResume(CandidateResumeModel candidateResumeModel)
        {
            try
            {
                _logger.LogInformation("API post for cand resume called");
                string email = "";
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
                var candidateResume = await _repo.AddCandidateResume(candidateResumeModel, email);
                if (candidateResume == null)
                {
                    return BadRequest();
                }
                return candidateResume;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }

        }

        [HttpPost("ResumeUpload")]
        public async Task<ActionResult<FilesModel>> AddResume(FilesModel files)
        {
            try
            {
                _logger.LogInformation("API put for resume upload called");

                _logger.LogInformation("API post for cand resume called");
                string email = "";
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
                var resume = await _repo.AddResume(files, email);
                if (resume == null)
                {
                    return BadRequest();
                }
                return resume;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }
        [HttpPost("skills")]
        public async Task<ActionResult<SkillsListModel>> AddSkills(SkillsListModel skillsListModel)
        {
            var skills = await _repo.AddSkills(skillsListModel);
            if (skills == null)
            {
                return null;
            }
            return skills;
        }

        [HttpGet("skills")]
        public async Task<List<SkillsModel>> GetSkills()
        {
            _logger.LogInformation("API post for cand resume called");
            string email = "";
            var list = new List<object>();
            foreach (var claim in User.Claims)
            {
                list.Add(claim.Value);
            }
            var userName = list[0];
            email = userName.ToString();
            var skills = await _repo.GetSkills(email);
            if (skills == null)
            {
                return null;
            }
            return skills;
        }

        [HttpGet("GetDetailsById")]
        public async Task<ActionResult<CandidateDetailsModel>> GetDetailsById()
        {
            try
            {
                _logger.LogInformation("API get for cand detatils called");
                _logger.LogInformation("API post for cand resume called");
                string email = "";
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
                var candDetailsById = await _repo.GetDetailsById(email);
                if (candDetailsById == null)
                {
                    return null;
                }
                return candDetailsById;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        [HttpGet("GetResumeById")]
        public async Task<ActionResult<CandidateResumeModel>> GetResumeById()
        {
            try
            {
                _logger.LogInformation("API post for resume detatils called");
                _logger.LogInformation("API post for cand resume called");
                string email = "";
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
                var candResumeById = await _repo.GetResumeById(email);
                if (candResumeById == null)
                {
                    return null;
                }
                return candResumeById;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        [HttpGet("GetResume")]
        public async Task<ActionResult<FilesModel>> GetResume()
        {
            try
            {
                _logger.LogInformation("API put for view uploaded resume called");

                _logger.LogInformation("API post for cand resume called");
                string email = "";
                var list = new List<object>();
                foreach (var claim in User.Claims)
                {
                    list.Add(claim.Value);
                }
                var userName = list[0];
                email = userName.ToString();
                var yourResume = await _repo.GetResume(email);
                if (yourResume == null)
                {
                    return null;
                }
                return yourResume;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error => {ex.Message}");
                return null;
            }
        }

        [HttpPut("UpdateDetails")]
        public async Task<ActionResult<CandidateDetailsModel>> UpdateDetails(CandidateDetailsModel candidateDetails)
        {
            _logger.LogInformation("API put for cand detatils called");
            try
            {
                if (candidateDetails.CandidateDetailsId == 0)
                {
                    return NotFound();
                }
                var candDetail = await _repo.UpdateDetails(candidateDetails);
                return candDetail;
            }
            catch (Exception e)
            {
                _logger.LogError($"error => {e.Message}");
                return null;
            }
        }

        [HttpPut("UpdateResume")]
        public async Task<ActionResult<CandidateResumeModel>> UpdateResume(CandidateResumeModel candidateResume)
        {
            _logger.LogInformation("API put for cand resume called");
            try
            {
                if (candidateResume.CandidateResumeId == 0)
                {
                    return NotFound();
                }
                await _repo.UpdateResume(candidateResume);
                return candidateResume;
            }
            catch (Exception e)
            {
                _logger.LogError($"error => {e.Message}");
                return null;
            }
        }
    }
}
