using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class DataDbContext : DbContext
    {
        public virtual DbSet<CandidateDetails> CandidateDetails { get; set; }
        public virtual DbSet<CandidateResume> CandidateResume { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<HR> HR { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
    }
}
