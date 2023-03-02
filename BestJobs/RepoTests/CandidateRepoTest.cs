using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Repository;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using APILayer.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RepoTests
{
    public class CandidateRepoTest
    {
        DataDbContext context;
        IGenericRepo _genericRepo;
        ICandidateRepo candRepo;
        IMapper _mapper;
        [OneTimeSetUp]
        public void Setup()
        {
            
            var options = new DbContextOptionsBuilder<DataDbContext>()
           .UseInMemoryDatabase(databaseName: "BestJobDb").Options;
            context = new DataDbContext(options);
            var config = new MapperConfiguration(x => { x.AddProfile(new AutoMapper1());});
            _mapper = config.CreateMapper();
            _genericRepo = new GenericRepo(_mapper);
            candRepo = new CandidateRepo(context, _mapper, _genericRepo);
            context.CandidateDetails.Add(new CandidateDetails {CandidateDetailsId = 1, Email = "abc@abc.abc", FirstName = "abc", LastName = "def", DOB = DateTime.Now, Phone = "123456789", AddLine = "234", City = "abc", Country = "abc"}); 
            context.CandidateDetails.Add(new CandidateDetails {CandidateDetailsId = 2, Email = "def@def.def", FirstName = "ghi", LastName = "jkl", DOB = DateTime.Now, Phone = "123456789", AddLine = "234", City = "abc", Country = "abc"});
            context.CandidateResume.Add(new CandidateResume   {CandidateResumeId = 1, CandidateDetailsId = 1, TenthSchool = "CBSE", TenthSchoolPercentage = "45%", TwelfthSchool = "CBSE", TwelfthSchoolPercentage = "45%", GraduationSchool = "Tier I", GraduationSchoolPercentage = "45%", GraduationStream = "CSE", CurrentOrganization = "Ex ORG", CurrentCTC = "1LPA" });
            context.Files.Add(new Files { DocumentId = 1, Name = "sample.pdf", CandidateDetailsId = 1});
            context.SaveChanges();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Dispose();
        }

        [Test]
        [Order(1)]
        public void GetDetialsTest()
        {
            var getDetails1 = candRepo.GetDetailsById("abc@abc.abc");
            var getDetails2 = candRepo.GetDetailsById("def@def.def");
            Assert.AreEqual("abc", getDetails1.Result.FirstName);
            Assert.AreEqual("ghi", getDetails2.Result.FirstName);
        }

        [Test]
        [Order(2)]
        public void CreateDetailsTest()
        {
            var detailModel = new CandidateDetailsModel() { CandidateDetailsId = 3, Email = "ghi@ghi.ghi", FirstName = "mno", LastName = "pqr", DOB = DateTime.Now, Phone = "123456789", AddLine = "234", City = "abc", Country = "abc" };
            var detailsAdd = candRepo.AddCandidateDetails(detailModel);
            Assert.AreEqual("mno", detailsAdd.Result.FirstName);
        }


        [Test]
        [Order(3)]
        public void GetResumeTest()
        {
            var getResume = candRepo.GetResumeById("abc@abc.abc");
            Assert.AreEqual("Tier I", getResume.Result.GraduationSchool);
        }

        [Test]
        [Order(4)]
        public void CreateResumeTest()
        {
            var resumeModel = new CandidateResumeModel() { CandidateResumeId = 2, CandidateDetailsId = 0, TenthSchool = "ICSE", TenthSchoolPercentage = "45%", TwelfthSchool = "CBSE", TwelfthSchoolPercentage = "45%", GraduationSchool = "Tier I", GraduationSchoolPercentage = "45%", GraduationStream = "CSE", CurrentOrganization = "Ex ORG", CurrentCTC = "1LPA" };
            var resumeAdd = candRepo.AddCandidateResume(resumeModel, "abc@abc.abc");
            Assert.AreEqual("ICSE", resumeAdd.Result.TenthSchool);
        }

        [Test]
        [Order(5)]
        public async Task UpdateDetailsTest()
        {
            var getDetails = await context.CandidateDetails.FindAsync(1);
            context.Entry(getDetails).State = EntityState.Detached;
            CandidateDetailsModel model = new CandidateDetailsModel();
            model.CandidateDetailsId = getDetails.CandidateDetailsId;
            model.AddLine = getDetails.AddLine;
            model.FirstName = "Test Change"; 
            model.LastName = getDetails.LastName;
            model.Country = getDetails.Country;
            model.City = getDetails.City;
            model.DOB = getDetails.DOB;
            model.Phone = getDetails.Phone;
            model.Email = getDetails.Email;
            var getDetailsAfterChange = await candRepo.UpdateDetails(model);
            Assert.AreEqual("Test Change", getDetailsAfterChange.FirstName);
        }

        [Test]
        [Order(6)]
        public async Task UpdateResumeTest()
        {           
            var getResume = await context.CandidateResume.FindAsync(1);
            context.Entry(getResume).State = EntityState.Detached;
            CandidateResumeModel candidateResume = new CandidateResumeModel();
            candidateResume.TwelfthSchool = getResume.TwelfthSchool;
            candidateResume.TwelfthSchoolPercentage = getResume.TwelfthSchoolPercentage;
            candidateResume.TenthSchool = getResume.TenthSchool;    
            candidateResume.TenthSchoolPercentage = "95%";
            candidateResume.CurrentCTC = getResume.CurrentCTC;
            candidateResume.CurrentOrganization = getResume.CurrentOrganization;
            candidateResume.CandidateDetailsId = getResume.CandidateDetailsId;
            candidateResume.CandidateResumeId = getResume.CandidateResumeId;
            candidateResume.GraduationSchool = getResume.GraduationSchool;
            candidateResume.GraduationSchoolPercentage = getResume.GraduationSchoolPercentage;
            candidateResume.GraduationStream = getResume.GraduationStream;           
            var getResumeAfterChange = await candRepo.UpdateResume(candidateResume);
            Assert.AreEqual("95%", getResumeAfterChange.TenthSchoolPercentage);
        }

        [Test]
        [Order(7)]
        public async Task ResumeUpload()
        {
            var getResume = await candRepo.GetResume("abc@abc.abc");
            Assert.AreEqual("sample.pdf", getResume.Name);
        }

        [Test]
        [Order(8)]
        public async Task AddResume()
        {
            var fileModel = new FilesModel() { CandidateDetailsId = 1, Name = "sample1.pdf", DocumentId = 3 };
            var fileModelTest = await candRepo.AddResume(fileModel,"abc@abc.abc");
            Assert.AreEqual("sample1.pdf", fileModelTest.Name);
        }

    }
}