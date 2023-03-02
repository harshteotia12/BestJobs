using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    /// <summary>
    /// Candidate Details Table
    /// where candidate can fill he basic details such as name, phone, email, age, address
    /// </summary>
    /// 
    [Table("CandidateDetails")]
    public class CandidateDetails
    {
        [Key][Required][Column(TypeName = "int")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateDetailsId { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string Email { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string FirstName { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string LastName { get; set; }

        [DataType("DateTime")][Required]
        public DateTime DOB { get; set; }

        [DataType("varchar(15)")][StringLength(15)][Required]
        public string Phone { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string AddLine { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string City { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string Country { get; set; }

        public ICollection<CandidateResume> CandidateResume { get; set; }
        public ICollection<Files> Files { get; set; }

    }
}


//[DataType(DataType.PhoneNumber)]
//[Display(Name = "Phone Number")]
//[Required(ErrorMessage = "Phone Number Required!")]
//[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
//                   ErrorMessage = "Entered phone format is not valid.")]
//public string PhoneNumber { get; set; }