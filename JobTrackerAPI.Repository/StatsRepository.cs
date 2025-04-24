using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Repository.Data;
using JobTrackerAPI.Repository.Query;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private readonly AppDbContext _context;

        public StatsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationCountDto>> GetJobsByLocationAsync(JobQueryParameters filters)
        {
            var jobs = _context.Jobs.AsQueryable();
            jobs = JobQueryBuilder.ApplyFilters(jobs, filters);

            return await jobs
                .Where(j => !string.IsNullOrEmpty(j.Location))
                .GroupBy(j => j.Location!)
                .Select(g => new LocationCountDto
                {
                    Location = g.Key,
                    Count = g.Count()
                })
                .OrderBy(l => l.Location)
                .ToListAsync();
        }

        public async Task<IEnumerable<StatusCountDto>> GetJobsByStatusAsync(JobQueryParameters filters)
        {
            var jobs = _context.Jobs.AsQueryable();
            jobs = JobQueryBuilder.ApplyFilters(jobs, filters);

            return await jobs
                .GroupBy(j => j.Status)
                .Select(g => new StatusCountDto
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .OrderBy(s => s.Status)
                .ToListAsync();
        }

        public async Task<IEnumerable<MonthlyStatusStatsDto>> GetJobsPerMonthAsync()
        {
            return await _context.Jobs
                .GroupBy(j => new { j.AppliedAt.Year, j.AppliedAt.Month })
                .Select(g => new MonthlyStatusStatsDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Pending = g.Count(j => j.Status == "pending"),
                    Interview = g.Count(j => j.Status == "interview"),
                    Rejected = g.Count(j => j.Status == "rejected")
                })
                .OrderBy(s => s.Year).ThenBy(s => s.Month)
                .ToListAsync();
        }
    }
}