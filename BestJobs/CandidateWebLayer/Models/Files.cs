using System;

namespace CandidateWebLayer.Models
{
    public class Files
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CandidateDetailsId { get; set; }
    }
}
