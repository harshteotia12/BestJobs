using System;

namespace BusinessLogicLayer.Models
{
    public class AllJobsModel
    {
        public int JobsId { get; set; }
        public int HRId { get; set; }
        public string JobsName { get; set; }
        public string JobsSkill { get; set; }
        public int JobsPackage { get; set; }
        public DateTime JobsPostDate { get; set; }
        public string JobsDescription { get; set; }
        public string UserName { get; set; }
        public string HRName { get; set; }
        public int HRYOE { get; set; }
        public string Orgname { get; set; }
        public byte[] OrgPhoto { get; set; }
        public bool IsRejected { get; set; }    
    }
}
