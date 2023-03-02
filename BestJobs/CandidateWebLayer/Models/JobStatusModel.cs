namespace CandidateWebLayer.Models
{
    public class JobStatusModel
    {
        public int JobStatusId { get; set; }
        public string HRUserName { get; set; }
        public string CandidateUserName { get; set; }
        public bool IsSelected { get; set; }
        public int JobsId { get; set; }
        public string JobsName { get; set; }
        public bool IsRejected { get; set; }
        public bool IsComleted { get; set; }
    }
}