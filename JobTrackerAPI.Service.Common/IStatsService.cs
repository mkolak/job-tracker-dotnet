using JobTrackerAPI.Model.DTOs;

namespace JobTrackerAPI.Service.Common
{
    public interface IStatsService
    {
        Task<IEnumerable<LocationCountDto>> GetJobsByLocationAsync(JobQueryParameters query);
        Task<IEnumerable<StatusCountDto>> GetJobsByStatusAsync(JobQueryParameters query);
        Task<IEnumerable<MonthlyStatusStatsDto>> GetJobsPerMonthAsync();
    }
}