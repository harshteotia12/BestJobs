using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Table("HR")]
    public class HR
    {
        [Key][Required][Column(TypeName = "int")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HRId { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string HRName { get; set; }
        [DataType("int")]
        public int HRYOE { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string UserName { get; set; }

        [DataType("varchar(50)")][StringLength(50)][Required]
        public string Orgname { get; set; }

        public byte[] OrgPhoto { get; set; }
        public ICollection<Jobs> Jobs { get; set; }

    }
}
