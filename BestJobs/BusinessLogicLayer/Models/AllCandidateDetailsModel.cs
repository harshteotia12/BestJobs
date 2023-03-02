using System;


namespace BusinessLogicLayer.Models
{
    public class AllCandidateDetailsModel
    {
        public int CandidateDetailsId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string AddLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CandidateResumeId { get; set; }
        public string TenthSchool { get; set; }
        public string TenthSchoolPercentage { get; set; }
        public string TwelfthSchool { get; set; }
        public string TwelfthSchoolPercentage { get; set; }
        public string GraduationSchool { get; set; }
        public string GraduationSchoolPercentage { get; set; }
        public string GraduationStream { get; set; }
        public string CurrentOrganization { get; set; }
        public string CurrentCTC { get; set; }
        public int JobStatusId { get; set; } 
    }
}
