using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using APILayer.Controllers;
using APILayer.Models;
using BusinessLogicLayer.Repository;
using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ControllersTest
{
    public class JobsControllerTest
    {
        private readonly JobsController controller;
        private readonly Mock<ILogger<JobsController>> logger = new Mock<ILogger<JobsController>>();
        private readonly Mock<ICandidateRepo> candRepo = new Mock<ICandidateRepo>();
        public JobsControllerTest()
        {
            controller = new JobsController(candRepo.Object, logger.Object);
        }


        [Fact]
        public async Task GetAllJobsById_Successfull()
        {
            byte[] x;
            x = new byte[] { 1, 2, 3 };
            AllJobsModel jobsModel = (new AllJobsModel { JobsId = 1, JobsName = "ABC", JobsDescription = "GCB", HRId = 1, JobsPackage = 58984, UserName = "abc@abc.com" , OrgPhoto = x , IsRejected = false, HRYOE = 5 , HRName = "HARYANA", JobsPostDate = DateTime.Now, JobsSkill = "C++ , DS", Orgname = "Punjab"});
            candRepo.Setup(x => x.GetAllJobsById(jobsModel.JobsId)).ReturnsAsync(jobsModel);
            var result = await controller.GetAllJobsById(1);
            var viewResult = Assert.IsType<AllJobsModel>(result);
            var model = Assert.IsAssignableFrom<AllJobsModel>(viewResult);
            Assert.Equal(jobsModel.JobsId, model.JobsId);
        }


        [Fact]
        public async Task GetAllJobs_Successfull()
        {
            byte[] x;
            x = new byte[] { 1, 2, 3 };
            List<AllJobsModel> jobsModels = new List<AllJobsModel>();
            jobsModels.Add(new AllJobsModel { JobsId = 1, JobsName = "ABC", JobsDescription = "GCB", HRId = 1, JobsPackage = 58984, UserName = "abc@abc.com", OrgPhoto = x, IsRejected = false, HRYOE = 5, HRName = "HARYANA", JobsPostDate = DateTime.Now, JobsSkill = "C++ , DS", Orgname = "Punjab" });
            jobsModels.Add(new AllJobsModel { JobsId = 2, JobsName = "DEF", JobsDescription = "GHB", HRId = 2, JobsPackage = 58984, UserName = "abd@abc.com", OrgPhoto = x, IsRejected = false, HRYOE = 5, HRName = "HARYANA", JobsPostDate = DateTime.Now, JobsSkill = "C++ , DS", Orgname = "Punjab" });
            jobsModels.Add(new AllJobsModel { JobsId = 3, JobsName = "GFH", JobsDescription = "VGB", HRId = 3, JobsPackage = 58984, UserName = "abe@abc.com", OrgPhoto = x, IsRejected = false, HRYOE = 5, HRName = "HARYANA", JobsPostDate = DateTime.Now, JobsSkill = "C++ , DS", Orgname = "Punjab" });
            jobsModels.Add(new AllJobsModel { JobsId = 4, JobsName = "GTY", JobsDescription = "TYR", HRId = 4, JobsPackage = 58984, UserName = "abf@abc.com", OrgPhoto = x, IsRejected = false, HRYOE = 5, HRName = "HARYANA", JobsPostDate = DateTime.Now, JobsSkill = "C++ , DS", Orgname = "Punjab" });
            candRepo.Setup(x => x.GetAllJobs("abc@abc.com",1)).ReturnsAsync(jobsModels);
            var result = await controller.GetAllJobs(1,true, "abc@abc.com");
            var viewResult = Assert.IsType<List<AllJobsModel>>(result);
            var model = Assert.IsAssignableFrom<List<AllJobsModel>>(viewResult);
            for (int i = 0; i < model.Count; i++)
            {
                Assert.Equal(jobsModels[i].JobsId, model[i].JobsId);
                Assert.Equal(jobsModels[i].HRId, model[i].HRId);
                Assert.Equal(jobsModels[i].JobsName, model[i].JobsName);
            }

        }
    }
}