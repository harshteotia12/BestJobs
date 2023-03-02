using System.Collections.Generic;

namespace HRWebLayer.Models
{
    public class HRModel
    {
        public int HRId { get; set; }
        public string HRName { get; set; }
        public int HRYOE { get; set; }
        public string UserName { get; set; }
        public string Orgname { get; set; }

        public byte[] OrgPhoto { get; set; }

    }
}
