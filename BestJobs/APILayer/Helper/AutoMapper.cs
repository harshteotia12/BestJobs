using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer;

namespace APILayer.Helper
{
    public class AutoMapper1 : Profile
    {
        public AutoMapper1()
        {
            CreateMap<CandidateDetails, CandidateDetailsModel>().ReverseMap();
            CreateMap<CandidateResume, CandidateResumeModel>().ReverseMap();
            CreateMap<Files, FilesModel>().ReverseMap();
            CreateMap<Skills, SkillsModel>().ReverseMap();
            CreateMap<HR, HRModel>().ReverseMap();
            CreateMap<Jobs, JobsModel>().ReverseMap();
            CreateMap<JobStatus, JobStatusModel>().ReverseMap();
        }
    }
}
