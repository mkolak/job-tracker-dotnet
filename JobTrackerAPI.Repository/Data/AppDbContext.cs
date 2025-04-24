using JobTrackerAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }

        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<InterviewEntity> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<JobEntity>()
                .HasMany(j => j.Interviews)
                .WithOne(i => i.Job)
                .HasForeignKey(i => i.JobAdvertisementId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
