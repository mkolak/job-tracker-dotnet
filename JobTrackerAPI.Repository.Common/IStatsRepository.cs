using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Service.DTOs;

namespace JobTrackerAPI.Repository.Common
{
    public interface IStatsRepository
    {
        Task<IEnumerable<LocationCountDto>> GetJobsByLocationAsync(JobQueryParameters filters);
        Task<IEnumerable<StatusCountDto>> GetJobsByStatusAsync(JobQueryParameters filters);
        Task<IEnumerable<MonthlyStatusStatsDto>> GetJobsPerMonthAsync();
    }
}