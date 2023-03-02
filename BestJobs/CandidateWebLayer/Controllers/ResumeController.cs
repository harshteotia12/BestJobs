using CandidateWebLayer.Helper;
using CandidateWebLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CandidateWebLayer.Controllers
{
    [CustomAuthorization]
    public class ResumeController : Controller
    {
        private readonly ILogger<ResumeController> _logger;
        private readonly IAPI _APIUrl;
        public ResumeController(ILogger<ResumeController> logger,IAPI APiUrl)
        {
            _APIUrl = APiUrl;   
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                _logger.LogInformation(" Index of resume ");
                Files files;
                HttpClient client = _APIUrl.Initial();
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await client.GetAsync("api/Candidate/GetResume");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    files = JsonConvert.DeserializeObject<Files>(result);
                    if (files != null)
                    {
                        return RedirectToAction("ViewResume", "Resume");
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
        public async Task<ActionResult> Index(IFormFile files)
        {
            try
            {
                _logger.LogInformation("User Uploading Resume");
                HttpClient client = _APIUrl.Initial();
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(files.FileName);
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var objfiles = new Files()
                        {
                            DocumentId = 0,
                            Name = newFileName,
                            FileType = fileExtension,
                            CreatedOn = DateTime.Now
                        };

                        using (var target = new MemoryStream())
                        {
                            files.CopyTo(target);
                            objfiles.DataFiles = target.ToArray();
                        }
                        var JwtToken1 = HttpContext.Session.GetString("JwtToken");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken1);
                        var insert = await client.PostAsync("api/Candidate/ResumeUpload", new StringContent(JsonConvert.SerializeObject(objfiles), Encoding.UTF8, "application/json"));
                        if (insert.IsSuccessStatusCode)
                        {
                            HttpContext.Session.SetString("Resume", "done");
                        }
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

        public async Task<IActionResult> ViewResume()
        {
            try
            {
                _logger.LogInformation("User Viewing Resume");
                Files files = new Files();
                HttpClient client = _APIUrl.Initial();
                var JwtToken = HttpContext.Session.GetString("JwtToken");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
                HttpResponseMessage response = await client.GetAsync("api/Candidate/GetResume");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    files = JsonConvert.DeserializeObject<Files>(result);
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
    }
}