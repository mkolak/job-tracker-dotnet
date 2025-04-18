using JobTrackerAPI.Common.Query;
using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context) { 
            _context = context; 
        }

        public async Task<(IEnumerable<Job>, int TotalCount)> GetAllAsync(JobQueryParameters query) {
            var jobs = _context.Jobs.AsQueryable();

            jobs = JobQueryBuilder.ApplyFilters(jobs, query);

            jobs = JobQueryBuilder.ApplySort(jobs, query);

            var total = await jobs.CountAsync();

            jobs = jobs
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit);

            var result = await jobs.Include(j => j.Interviews).ToListAsync();

            return (result, total);
        }

        public async Task<Job?> GetByIdAsync(Guid id) { 
            return await _context.Jobs
                .Include(j => j.Interviews)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<Job> CreateAsync(Job job) { 
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job?> UpdateAsync(Job job){
            var existing = await _context.Jobs.FindAsync(job.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(job);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id) {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return false;

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
