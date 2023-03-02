using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    [Table("JobStatus")]
    public class JobStatus
    {
        [Key][Required][Column(TypeName = "int")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobStatusId { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string HRUserName { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string CandidateUserName { get; set; }
        public bool IsSelected { get; set; }
        public bool IsRejected { get; set; }
        public bool IsComleted { get; set; }
        [ForeignKey("HR")]
        public int JobsId { get; set; }
        public Jobs Jobs { get; set; }
    }
}