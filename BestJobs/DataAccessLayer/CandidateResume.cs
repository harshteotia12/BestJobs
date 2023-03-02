using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    /// <summary>
    /// Candidate Resume Table
    /// where candidate can fill he Professional details such as Percentages, skills, currenct org and ctc!
    /// </summary>
    /// 
    [Table("CandidateResume")]
    public class CandidateResume
    {
        [Key][Required][Column(TypeName = "int")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateResumeId { get; set; }

        [ForeignKey("CandidateDetails")]
        public int CandidateDetailsId { get; set; }
        public CandidateDetails CandidateDetails { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string TenthSchool { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string TenthSchoolPercentage { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string TwelfthSchool { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string TwelfthSchoolPercentage { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string GraduationSchool{ get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string GraduationSchoolPercentage { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string GraduationStream { get; set; }

        [DataType("varchar(50)")][StringLength(50)]
        public string CurrentOrganization { get; set; }

        [DataType("varchar(50)")][StringLength(50)]
        public string CurrentCTC { get; set; }

    }
}


//[DataType(DataType.PhoneNumber)]
//[Display(Name = "Phone Number")]
//[Required(ErrorMessage = "Phone Number Required!")]
//[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
//                   ErrorMessage = "Entered phone format is not valid.")]
//public string PhoneNumber { get; set; }