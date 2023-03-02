using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public interface ICandidateRepo
    {

        Task<CandidateDetailsModel> AddCandidateDetails(CandidateDetailsModel candidateDetailsModels);
        Task<CandidateResumeModel> AddCandidateResume(CandidateResumeModel candidateResumeModel,string userName);
        Task<CandidateDetailsModel> GetDetailsById(string name);
        Task<CandidateResumeModel> GetResumeById(string name);
        Task<CandidateDetailsModel> UpdateDetails(CandidateDetailsModel candidateDetails);
        Task<CandidateResumeModel> UpdateResume(CandidateResumeModel candidateResume);
        Task<FilesModel> AddResume(FilesModel filesModel,string name);
        Task<FilesModel> GetResume(string name);
        Task<SkillsListModel> AddSkills(SkillsListModel skillsListModel);
        Task<List<SkillsModel>> GetSkills(string name);
        Task<List<AllJobsModel>> GetAllJobs(string email,int Id);
        Task<AllJobsModel> GetAllJobsById(int Id);
        Task<string> Apply(int Id,string email);
        Task<List<JobStatusModel>> JobsApplied(string email);
        Task<int> getcount(string email);
        Task<List<AllJobsModel>> Search(string email,string value);
    }
}
