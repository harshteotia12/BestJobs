using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public interface IHRRepo
    {
        Task<HRModel> AddHR(HRModel hRModel);
        Task<JobsModel> AddJobs(JobsModel jobsModel);
        Task<List<JobsModel>> GetJobs(string UserName);
        Task<HRModel> GetHr(string UserName);
        Task<HRModel> EditHr(HRModel hRModel);
        Task<string> DeleteJob(int Id);
        Task<JobsModel> GetJobsById(int Id);    
        Task<JobsModel> EditJobs(JobsModel jobsModel);
        Task<List<HRNotiModel>> HRNoti(string email);
        Task<AllCandidateDetailsModel> CandidateDetails(int Id, int JobsId);
        Task<List<SkillsModel>> ViewSkills(int Id);
        Task<FilesModel> GetResume(int Id);
        Task<JobStatusModel> Accept(int Id);
        Task<JobStatusModel> Reject(int Id);
        Task<string[]> ViewJobSkills(int Id);
        Task<List<SelectedModel>> Selected(string email);
    }
}
