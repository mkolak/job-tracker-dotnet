using JobTrackerAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Job>()
                .HasMany(j => j.Interviews)
                .WithOne(i => i.Job)
                .HasForeignKey(i => i.JobAdvertisementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
