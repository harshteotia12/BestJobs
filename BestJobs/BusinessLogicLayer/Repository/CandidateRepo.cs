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
    public class CandidateRepo : ICandidateRepo
    {
        //Readonly Property
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepo _genericRepo;
        /// <summary>
        /// Constructor to initialize the property
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CandidateRepo(DataDbContext context, IMapper mapper, IGenericRepo genericRepo)
        {
            _context = context;
            _mapper = mapper;
            _genericRepo = genericRepo;
        }


        public async Task<CandidateDetailsModel> AddCandidateDetails(CandidateDetailsModel candidateDetailsModels)
        {
            try
            { 
                CandidateDetails candidateDetails = new CandidateDetails();
                var data = _genericRepo.Add<CandidateDetailsModel,CandidateDetails>(candidateDetailsModels, candidateDetails);
                _context.CandidateDetails.Add(data);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception)
            {
                return null;
            }
            return candidateDetailsModels;
        }
        public async Task<CandidateResumeModel> AddCandidateResume(CandidateResumeModel candidateResumeModel,string userName)
        {
            var listOfDetails = await _context.CandidateDetails.Select(x => new CandidateDetailsModel
            { 
                CandidateDetailsId = x.CandidateDetailsId,
                Email = x.Email,    
            }).ToListAsync();

            foreach(var details in listOfDetails)
            {
                if(details.Email.Equals(userName))
                {
                    candidateResumeModel.CandidateDetailsId = details.CandidateDetailsId;
                }
            }
            try
            {
                CandidateResume candidateResume = new CandidateResume();
                _mapper.Map(candidateResumeModel, candidateResume);
                _context.CandidateResume.Add(candidateResume);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                return null;
            }
            return candidateResumeModel;
        }

        public async Task<FilesModel> AddResume(FilesModel filesModel,string name)
        {
            var listOfDetails = await _context.CandidateDetails.Select(x => new CandidateDetailsModel
            {
                CandidateDetailsId = x.CandidateDetailsId,
                Email = x.Email,
            }).ToListAsync();

            foreach (var details in listOfDetails)
            {
                if (details.Email.Equals(name))
                {
                    filesModel.CandidateDetailsId = details.CandidateDetailsId;
                }
            }
            try
            {
                Files file = new Files();
                _mapper.Map(filesModel, file);
                _context.Files.Add(file);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                return null;
            }
            return filesModel;
        }

        public async Task<FilesModel> GetResume(string name)
        {
            var list = await (from x in _context.CandidateDetails
                              join y in _context.Files on x.CandidateDetailsId equals y.CandidateDetailsId
                              select new FilesModel
                              {
                                  Email = x.Email,
                                  FileType = y.FileType,
                                  DataFiles = y.DataFiles,
                                  DocumentId = y.DocumentId,
                                  Name = y.Name,    
                                  CreatedOn = y.CreatedOn,
                                  CandidateDetailsId=y.CandidateDetailsId
                              }).ToListAsync();
            foreach (var details in list)
            {
                if (details.Email.Equals(name))
                {
                    return details;
                }
            }
            return null;
        }
        public async Task<CandidateDetailsModel> GetDetailsById(string name)
        {
            var list = await _context.CandidateDetails.Select(x => new CandidateDetailsModel
            {
                CandidateDetailsId= x.CandidateDetailsId,
                City = x.City,
                Country = x.Country,    
                Email= x.Email,
                Phone = x.Phone,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DOB = x.DOB,
                AddLine = x.AddLine
            }).ToListAsync();
            foreach( var details in list)
            {
                if(details.Email.Equals(name))
                {
                    return details;
                }
            }
            return null;
        }

        public async Task<CandidateResumeModel> GetResumeById(string name)
        {
            var list = await (from x in _context.CandidateDetails
                        join y in _context.CandidateResume on x.CandidateDetailsId equals y.CandidateDetailsId
                        select new CandidateResumeModel
                        {
                            CandidateResumeId = y.CandidateResumeId,
                            CandidateDetailsId = x.CandidateDetailsId,
                            TenthSchool = y.TenthSchool,
                            TenthSchoolPercentage = y.TenthSchoolPercentage,
                            TwelfthSchool = y.TwelfthSchool,
                            TwelfthSchoolPercentage = y.TwelfthSchoolPercentage,
                            GraduationSchool = y.GraduationSchool,
                            GraduationSchoolPercentage = y.GraduationSchoolPercentage,
                            GraduationStream = y.GraduationStream,
                            CurrentCTC = y.CurrentCTC,
                            CurrentOrganization = y.CurrentOrganization,
                            Email=x.Email
                        }).ToListAsync();
            foreach (var details in list)
            {
                if (details.Email.Equals(name))
                {
                    return details;
                }
            }
            return null;
        }

        public async Task<CandidateDetailsModel> UpdateDetails(CandidateDetailsModel candidateDetails)
        {
            
            CandidateDetails candDetail = new CandidateDetails();
            _mapper.Map(candidateDetails, candDetail);
            try
            {
                _context.Entry(candDetail).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return candidateDetails;
        }

        public async Task<CandidateResumeModel> UpdateResume(CandidateResumeModel candidateResume)
        {
            CandidateResume candResume = new CandidateResume();
            _mapper.Map(candidateResume, candResume);
            try
            { 
                _context.Entry(candResume).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return null;
            }
            return candidateResume;
        }

        public async Task<SkillsListModel> AddSkills(SkillsListModel skillsListModel)
        {
            foreach(var skillModel in skillsListModel.Skills)
            {
                Skills skill = new Skills();
                _mapper.Map(skillModel, skill);
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();
            }
            return skillsListModel;
        }

        public async Task<List<SkillsModel>> GetSkills(string name)
        {
            var list = await (from x in _context.Skills
                              where x.UserName.Contains(name)
                              select new SkillsModel
                              {
                                  SkillName = x.SkillName,
                                  SkillProficiency = x.SkillProficiency,
                              }).ToListAsync();
            List<SkillsModel> skillsModels = new List<SkillsModel>();
            foreach (var skill in list)
            {
                skillsModels.Add(skill);
            }
            return skillsModels;
        }
        public async Task<int> getcount(string email)
        {
            var listOfJobs = await (from x in _context.Jobs
                                    join y in _context.HR on x.HRId equals y.HRId
                                    select new AllJobsModel
                                    {
                                        JobsId = x.JobsId,
                                        HRId = y.HRId,
                                        JobsName = x.JobsName,
                                        JobsSkill = x.JobsSkill,
                                        JobsPackage = x.JobsPackage,
                                        JobsPostDate = x.JobsPostDate,
                                        JobsDescription = x.JobsDescription,
                                        UserName = y.UserName,
                                        HRName = y.HRName,
                                        HRYOE = y.HRYOE,
                                        Orgname = y.Orgname,
                                        OrgPhoto = y.OrgPhoto,
                                    }).ToListAsync();

            var listOfJobsStatus = await (from x in _context.JobStatus
                                          where x.CandidateUserName == email
                                          select new JobStatusModel
                                          {
                                              JobsId = x.JobsId,
                                              IsRejected = x.IsRejected
                                          }).ToListAsync();
            var listToReturn = new List<AllJobsModel>();
            int temp = 0;
            int count = listOfJobsStatus.Count;
            foreach (var job in listOfJobs)
            {
                temp = 0;
                foreach (var status in listOfJobsStatus)
                {
                    if (job.JobsId == status.JobsId && status.IsRejected == false)
                    {
                        listToReturn.Add(job);
                    }
                    else if (job.JobsId != status.JobsId)
                    {
                        temp++;
                    }
                }
                if (temp == count)
                {
                    listToReturn.Add(job);
                }

            }
            return listToReturn.Count;
        }

        public async Task<List<AllJobsModel>> Search(string email,string value)
        {
            var listOfJobs = await (from x in _context.Jobs
                                    join y in _context.HR on x.HRId equals y.HRId
                                    where x.JobsName.ToLower().Contains(value.ToLower()) || x.JobsSkill.ToLower().Contains(value.ToLower()) || y.Orgname.ToLower().Contains(value.ToLower())
                                    select new AllJobsModel
                                    {
                                        JobsId = x.JobsId,
                                        HRId = y.HRId,
                                        JobsName = x.JobsName,
                                        JobsSkill = x.JobsSkill,
                                        JobsPackage = x.JobsPackage,
                                        JobsPostDate = x.JobsPostDate,
                                        JobsDescription = x.JobsDescription,
                                        UserName = y.UserName,
                                        HRName = y.HRName,
                                        HRYOE = y.HRYOE,
                                        Orgname = y.Orgname,
                                        OrgPhoto = y.OrgPhoto,
                                    }).ToListAsync();

            var listOfJobsStatus = await (from x in _context.JobStatus
                                          where x.CandidateUserName == email
                                          select new JobStatusModel
                                          {
                                              JobsId = x.JobsId,
                                              IsRejected = x.IsRejected
                                          }).ToListAsync();
            var listToReturn = new List<AllJobsModel>();
            int temp = 0;
            int count = listOfJobsStatus.Count;
            foreach (var job in listOfJobs)
            {
                temp = 0;
                foreach (var status in listOfJobsStatus)
                {
                    if (job.JobsId == status.JobsId && !status.IsRejected)
                    {
                        listToReturn.Add(job);
                    }
                    else if (job.JobsId != status.JobsId)
                    {
                        temp++;
                    }
                }
                if (temp == count)
                {
                    listToReturn.Add(job);
                }

            }
            return listToReturn;
        }
        public async Task<List<AllJobsModel>> GetAllJobs(string email,int Id)
        {
            if (Id < 1)
            {
                Id = 1;
            }
            int pgSize = 3;
            int recsCount = _context.Jobs.Count();
            var pager = new Pager(recsCount, Id, pgSize);
            int recSkip = (Id - 1) * pgSize;
            var listOfJobs = await (from x in _context.Jobs
                                    join y in _context.HR on x.HRId equals y.HRId
                                    select new AllJobsModel
                                    {
                                        JobsId = x.JobsId,
                                        HRId = y.HRId,
                                        JobsName = x.JobsName,
                                        JobsSkill = x.JobsSkill,
                                        JobsPackage = x.JobsPackage,
                                        JobsPostDate = x.JobsPostDate,
                                        JobsDescription = x.JobsDescription,
                                        UserName = y.UserName,
                                        HRName = y.HRName,
                                        HRYOE = y.HRYOE,
                                        Orgname = y.Orgname,
                                        OrgPhoto = y.OrgPhoto,
                                    }).ToListAsync();

            var listOfJobsStatus = await (from x in _context.JobStatus
                                          where x.CandidateUserName == email
                                          select new JobStatusModel
                                          {
                                              JobsId=x.JobsId,
                                              IsRejected = x.IsRejected  
                                          }).ToListAsync();
            var listToReturn = new List<AllJobsModel>();
            int temp = 0;
            int count = listOfJobsStatus.Count;
            foreach (var job in listOfJobs)
            {
                temp = 0;
                foreach(var status in listOfJobsStatus)
                {
                    if( job.JobsId==status.JobsId && !status.IsRejected)
                    {
                        listToReturn.Add(job);
                    }  
                    else if(job.JobsId != status.JobsId)
                    {
                        temp++;
                    }
                }
                if(temp == count)
                {
                    listToReturn.Add(job);
                }

            }
            var ordered = listToReturn.OrderBy(x => x.HRId).Skip(recSkip).Take(pager.PageSize).ToList();
            return ordered;
        }
        public async Task<AllJobsModel> GetAllJobsById(int Id)
        {
            var jobs = await (from x in _context.Jobs
                              join y in _context.HR on x.HRId equals y.HRId
                              where x.JobsId == Id 
                              select new AllJobsModel
                              {
                                  JobsId = x.JobsId,
                                  HRId = y.HRId,
                                  JobsName = x.JobsName,
                                  JobsSkill = x.JobsSkill,
                                  JobsPackage = x.JobsPackage,
                                  JobsPostDate = x.JobsPostDate,
                                  JobsDescription = x.JobsDescription,
                                  UserName = y.UserName,
                                  HRName = y.HRName,
                                  HRYOE = y.HRYOE,
                                  Orgname = y.Orgname,
                                  OrgPhoto = y.OrgPhoto
                              }).ToListAsync();
            return jobs[0];
        }

        public async Task<string> Apply(int Id,string email)
        {
            var jobs = await (from x in _context.Jobs
                              join y in _context.HR on x.HRId equals y.HRId
                              where x.JobsId == Id
                              select new AllJobsModel
                              {
                                  JobsId = x.JobsId,
                                  UserName = y.UserName
                              }).ToListAsync();
            JobStatusModel jobStatusModel = new JobStatusModel();
            jobStatusModel.JobsId = Id;
            jobStatusModel.HRUserName = jobs[0].UserName;
            jobStatusModel.CandidateUserName = email;
            jobStatusModel.IsSelected = false;
            JobStatus jobStatus = new JobStatus();
            _mapper.Map(jobStatusModel, jobStatus);
            _context.JobStatus.Add(jobStatus);
            await _context.SaveChangesAsync();
            return "applied";
        }

        public async Task<List<JobStatusModel>> JobsApplied(string email)
        {
            var listOfAppliedJobs = await (from x in _context.JobStatus
                                           join y in _context.Jobs on x.JobsId equals y.JobsId
                                           where x.CandidateUserName == email
                                           select new JobStatusModel
                                           {
                                               JobStatusId = x.JobStatusId,
                                               CandidateUserName = x.CandidateUserName,
                                               HRUserName = x.HRUserName,
                                               IsSelected=x.IsSelected,
                                               JobsId=x.JobsId,
                                               JobsName=y.JobsName,
                                               IsComleted = x.IsComleted,
                                               IsRejected=x.IsRejected
                                           }).ToListAsync();
            return listOfAppliedJobs;
        }

    }
}
