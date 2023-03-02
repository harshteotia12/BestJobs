using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebLayer.Models
{
    public class JobsModel
    {
        public int JobsId { get; set; }
        public int HRId { get; set; }
        public string JobsName { get; set; }
        public string JobsSkill { get; set; }
        public int JobsPackage { get; set; }
        public DateTime JobsPostDate { get; set; }
        public string JobsDescription { get; set; }
        public string UserName { get; set; }
    }
}
