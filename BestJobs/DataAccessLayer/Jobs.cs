using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Table("Jobs")]
    public class Jobs
    {
        [Key][Required][Column(TypeName = "int")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobsId { get; set; }

        [ForeignKey("HR")]
        public int HRId { get; set; }
        public HR HR { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string JobsName { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string JobsSkill { get; set; }

        [DataType("int")]
        public int JobsPackage { get; set; }

        [DataType("DateTime")][StringLength(50)][Required]
        public DateTime JobsPostDate { get; set; }


        [DataType("varchar(200)")][StringLength(200)][Required]
        public string JobsDescription { get; set; }

        public ICollection<JobStatus> JobStatus { get; set; }
    }
}
