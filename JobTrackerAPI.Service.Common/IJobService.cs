using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;

namespace JobTrackerAPI.Service.Common
{
    public interface IJobService
    {
        Task<(IEnumerable<Job> Jobs, int TotalCount)> GetAllAsync(JobQueryParameters query);
        Task<Job?> GetByIdAsync(Guid id);
        Task<Job> CreateAsync(Job job);
        Task<Job?> UpdateAsync(Job job);
        Task<bool> DeleteAsync(Guid id);
    }
}
