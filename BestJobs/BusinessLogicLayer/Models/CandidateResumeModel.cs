namespace BusinessLogicLayer.Models
{
    public class CandidateResumeModel
    {
        public int CandidateResumeId { get; set; }
        public int CandidateDetailsId { get; set; }
        public string TenthSchool { get; set; }
        public string TenthSchoolPercentage { get; set; }
        public string TwelfthSchool { get; set; }
        public string TwelfthSchoolPercentage { get; set; }
        public string GraduationSchool { get; set; }
        public string GraduationSchoolPercentage { get; set; }
        public string GraduationStream { get; set; }
        public string CurrentOrganization { get; set; }
        public string CurrentCTC { get; set; }
        public string Email { get; set; }

    }
}
