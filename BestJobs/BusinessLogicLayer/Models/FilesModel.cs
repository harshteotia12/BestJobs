using System;

namespace BusinessLogicLayer.Models
{
    public class FilesModel
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CandidateDetailsId { get; set; }
        public string Email { get; set; }
    }
}
