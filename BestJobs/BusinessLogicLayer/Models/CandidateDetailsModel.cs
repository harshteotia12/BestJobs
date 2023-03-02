using System;


namespace BusinessLogicLayer.Models
{
    public class CandidateDetailsModel
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
    }
}
