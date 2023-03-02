using System;
using System.ComponentModel.DataAnnotations;

namespace CandidateWebLayer.Models
{
    public class CandidateDetailsModel
    {
        public int CandidateDetailsId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
        public string AddLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
