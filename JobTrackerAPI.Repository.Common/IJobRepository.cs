using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;

namespace JobTrackerAPI.Repository.Common
{
    public interface IJobRepository
    {
        Task<(IEnumerable<Job>, int TotalCount)> GetAllAsync(JobQueryParameters query);
        Task<Job?> GetByIdAsync(Guid id);
        Task<Job> CreateAsync(Job job);
        Task<Job?> UpdateAsync(Job job);
        Task<bool> DeleteAsync(Guid id);
    }
}
