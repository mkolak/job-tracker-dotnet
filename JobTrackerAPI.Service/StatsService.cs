using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Service.Common;

namespace JobTrackerAPI.Service
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _repository;

        public StatsService(IStatsRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<LocationCountDto>> GetJobsByLocationAsync(JobQueryParameters query) => _repository.GetJobsByLocationAsync(query);

        public Task<IEnumerable<StatusCountDto>> GetJobsByStatusAsync(JobQueryParameters query) => _repository.GetJobsByStatusAsync(query);

        public Task<IEnumerable<MonthlyStatusStatsDto>> GetJobsPerMonthAsync() => _repository.GetJobsPerMonthAsync();
    }
}
