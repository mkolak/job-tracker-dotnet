using AutoMapper;
using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Repository.Data;
using JobTrackerAPI.Repository.Entities;
using JobTrackerAPI.Repository.Query;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public JobRepository(AppDbContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<Job>, int TotalCount)> GetAllAsync(JobQueryParameters query) {
            var jobsQuery = _context.Jobs.AsQueryable();

            jobsQuery = JobQueryBuilder.ApplyFilters(jobsQuery, query);

            jobsQuery = JobQueryBuilder.ApplySort(jobsQuery, query);

            var total = await jobsQuery.CountAsync();

            jobsQuery = jobsQuery
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit);

            var jobs = await jobsQuery.Include(j => j.Interviews).ToListAsync();

            var result = _mapper.Map<IEnumerable<Job>>(jobsQuery);

            return (result, total);
        }

        public async Task<Job?> GetByIdAsync(Guid id) {
            var entity = await _context.Jobs
                .Include(j => j.Interviews)
                .FirstOrDefaultAsync(j => j.Id == id);
            return _mapper.Map<Job>(entity);
        }

        public async Task<Job> CreateAsync(Job job) { 
            var entity = _mapper.Map<JobEntity>(job);
            _context.Jobs.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Job>(entity);
        }

        public async Task<Job?> UpdateAsync(Job job){
            var entity = _mapper.Map<JobEntity>(job);
            var existing = await _context.Jobs.FindAsync(entity.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Job>(existing);
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
