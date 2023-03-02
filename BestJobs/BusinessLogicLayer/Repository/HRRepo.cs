using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinessLogicLayer.Repository
{
    public class HRRepo : IHRRepo
    {
        //Readonly Property
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor to initialize the property
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public HRRepo(DataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<HRModel> AddHR(HRModel hRModel)
        {
            HR hr = new HR();
            _mapper.Map(hRModel, hr);
            _context.HR.Add(hr);
            await _context.SaveChangesAsync(); 
            return hRModel;
        }

        public async Task<JobsModel> AddJobs(JobsModel jobsModel)
        {
            string userName = jobsModel.UserName;
            var HrList = await (from x in _context.HR 
                                where x.UserName == userName 
                                select new HRModel
                                {
                                    HRId = x.HRId,
                                }).ToListAsync();
            jobsModel.HRId = HrList[0].HRId;
            jobsModel.JobsPostDate = DateTime.Now;
            Jobs job = new Jobs();  
            _mapper.Map(jobsModel, job);    
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return jobsModel;
        }

        public async Task<List<JobsModel>> GetJobs(string UserName)
        {
            var Jobs = await (from x in _context.HR
                              join y in _context.Jobs on x.HRId equals y.HRId
                              where x.UserName == UserName
                              select new JobsModel
                              {
                                  HRId = y.HRId,
                                  JobsId = y.JobsId,    
                                  JobsName = y.JobsName,    
                                  JobsSkill = y.JobsSkill,
                                  JobsPackage = y.JobsPackage,  
                                  JobsPostDate = y.JobsPostDate,  
                                  JobsDescription = y.JobsDescription
                              }).ToListAsync();
            //string[] jobs1 = Jobs[0].JobsSkill.Split(" , ");
            return Jobs;

        }

        public async Task<HRModel> GetHr(string UserName)
        {
            var HR = await (from x in _context.HR
                            where x.UserName == UserName
                            select new HRModel()
                            {
                                HRId=x.HRId,
                                HRName = x.HRName,
                                HRYOE = x.HRYOE,
                                Orgname = x.Orgname,
                                OrgPhoto = x.OrgPhoto,
                                UserName = x.UserName

                            }).ToListAsync();
            return HR[0];
        }
        public async Task<HRModel> EditHr(HRModel hRModel)
        {
            HR hr = new HR();
            _mapper.Map(hRModel, hr);
            _context.HR.Update(hr);
            await _context.SaveChangesAsync();
            return hRModel;
        }

        public async Task<string> DeleteJob(int Id)
        {
            var deleteJob = await _context.Jobs.FindAsync(Id);
            if (deleteJob == null)
            {
                return null;
            }
            _context.Jobs.Remove(deleteJob);
            await _context.SaveChangesAsync();  
            return $"job => {deleteJob.JobsName} deleted successfully";
        }

        public async Task<JobsModel> GetJobsById(int Id)
        {
            var jobs = await _context.Jobs.FindAsync(Id);
            JobsModel jobsModel = new JobsModel();  
            _mapper.Map(jobs, jobsModel);
            return jobsModel;
        }

        public async Task<JobsModel> EditJobs(JobsModel jobsModel)
        {
            Jobs jobs = new Jobs();
            _mapper.Map(jobsModel,jobs);
            _context.Jobs.Update(jobs); 
            await _context.SaveChangesAsync();  
            return jobsModel;
        }

        public async Task<List<HRNotiModel>> HRNoti(string email)
        {
            var notifications = await (from x in _context.Jobs
                                       join y in _context.JobStatus on x.JobsId equals y.JobsId
                                       join z in _context.CandidateDetails on y.CandidateUserName equals z.Email
                                       where y.HRUserName == email && y.IsComleted == false && y.IsRejected == false    
                                       select new HRNotiModel
                                       {
                                           UserName = z.Email,
                                           CandidateName = z.FirstName,
                                           CandidateId = z.CandidateDetailsId,
                                           JobsName = x.JobsName,
                                           JobsId = x.JobsId,
                                       }).ToListAsync();
            return notifications;
        }

        public async Task<AllCandidateDetailsModel> CandidateDetails(int Id, int JobsId)
        {
            var detailsOfCandidate = await (from x in _context.CandidateDetails
                                            join y in _context.CandidateResume on x.CandidateDetailsId equals y.CandidateDetailsId
                                            join z in _context.Files on x.CandidateDetailsId equals z.CandidateDetailsId
                                            join w in _context.JobStatus on x.Email equals w.CandidateUserName
                                            where x.CandidateDetailsId == Id && w.JobsId == JobsId
                                            select new AllCandidateDetailsModel
                                            {
                                                CandidateDetailsId = x.CandidateDetailsId,
                                                Email = x.Email,
                                                FirstName = x.FirstName,
                                                LastName = x.LastName,
                                                DOB = x.DOB,
                                                Phone = x.Phone,
                                                AddLine = x.AddLine,
                                                City = x.City,
                                                Country = x.Country,
                                                CandidateResumeId = y.CandidateResumeId,
                                                TenthSchool = y.TenthSchool,
                                                TenthSchoolPercentage = y.TenthSchoolPercentage,
                                                TwelfthSchool = y.TwelfthSchool,
                                                TwelfthSchoolPercentage =  y.TwelfthSchoolPercentage,
                                                GraduationSchool = y.GraduationSchool,
                                                GraduationSchoolPercentage = y.GraduationSchoolPercentage,
                                                GraduationStream = y.GraduationStream,
                                                CurrentOrganization = y.CurrentOrganization,
                                                CurrentCTC = y.CurrentCTC,
                                                JobStatusId = w.JobStatusId
                                            }).ToListAsync();
            return detailsOfCandidate[0];
        }

        public async Task<List<SkillsModel>> ViewSkills(int Id)
        {
            var listOfSkills = await (from x in _context.CandidateDetails
                                      join y in _context.Skills on x.Email equals y.UserName
                                      where x.CandidateDetailsId == Id
                                      select new SkillsModel
                                      {
                                          SkillName=y.SkillName,
                                          SkillProficiency=y.SkillProficiency,
                                      }).ToListAsync();
            return listOfSkills;
        }

        public async Task<FilesModel> GetResume(int Id)
        {
            var list = await (from x in _context.CandidateDetails
                              join y in _context.Files on x.CandidateDetailsId equals y.CandidateDetailsId
                              where x.CandidateDetailsId == Id
                              select new FilesModel
                              {
                                  Email = x.Email,
                                  FileType = y.FileType,
                                  DataFiles = y.DataFiles,
                                  DocumentId = y.DocumentId,
                                  Name = y.Name,
                                  CreatedOn = y.CreatedOn,
                                  CandidateDetailsId = y.CandidateDetailsId
                              }).ToListAsync();
            return list[0];
        }
        public async Task<JobStatusModel> Accept(int Id)
        {
            var jobstatus = await _context.JobStatus.FindAsync(Id);
            jobstatus.IsSelected = true;
            JobStatusModel model = new JobStatusModel();
            _mapper.Map(jobstatus,model);
            _context.JobStatus.Update(jobstatus);
            await _context.SaveChangesAsync();
            var email = jobstatus.CandidateUserName;
            var list = await (from x in _context.JobStatus
                              where x.CandidateUserName == email
                              select new JobStatusModel
                              {
                                  JobStatusId = x.JobStatusId
                              }).ToListAsync();
            foreach(var item in list)
            {
                var jobstatus1 = await _context.JobStatus.FindAsync(item.JobStatusId);
                jobstatus1.IsComleted = true;
                _context.JobStatus.Update(jobstatus1);
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task<JobStatusModel> Reject(int Id)
        {
            var jobstatus = await _context.JobStatus.FindAsync(Id);
            jobstatus.IsRejected = true;    
            _context.Update(jobstatus);
            await _context.SaveChangesAsync();
            JobStatusModel jobStatusMode = new JobStatusModel();
            _mapper.Map(jobstatus, jobStatusMode);
            return jobStatusMode;

        }

        public async Task<string[]> ViewJobSkills(int Id)
        {
            var listOfSkills = await (from x in _context.Jobs
                                      where x.JobsId == Id
                                      select new JobsModel
                                      {
                                          JobsSkill = x.JobsSkill
                                      }).ToListAsync();

          return listOfSkills[0].JobsSkill.Split(" , ");
           
        }

        public async Task<List<SelectedModel>> Selected(string email)
        {
            var list = await (from x in _context.Jobs
                              join y in _context.JobStatus on x.JobsId equals y.JobsId
                              join z in _context.CandidateDetails on y.CandidateUserName equals z.Email
                              where y.HRUserName == email && y.IsComleted
                              select new SelectedModel
                              {
                                  JobName = x.JobsName,
                                  CandidateName = String.Concat(z.FirstName,z.LastName)
                              }).ToListAsync();
            return list;
        }
    }
}
