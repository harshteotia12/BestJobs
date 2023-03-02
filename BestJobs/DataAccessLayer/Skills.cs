using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    [Table("Skills")]
    public class Skills
    {
        [Key][Required][Column(TypeName = "int")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillsId { get; set; }


        [DataType("varchar(50)")][StringLength(50)][Required]
        public string UserName { get; set; }


        [DataType("varchar(50)")][StringLength(50)][Required]
        public string SkillName { get; set; }

        [DataType("int")][Required]
        public int SkillProficiency { get; set; }

      
    }
}