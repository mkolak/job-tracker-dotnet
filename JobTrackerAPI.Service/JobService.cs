using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Service.Common;

namespace JobTrackerAPI.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _repository;

        public JobService(IJobRepository repository){
            _repository = repository;
        }

        public Task<(IEnumerable<Job> Jobs, int TotalCount)> GetAllAsync(JobQueryParameters query) => _repository.GetAllAsync(query);

        public Task<Job?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);
        public Task<Job> CreateAsync(Job job) => _repository.CreateAsync(job);
        public Task<Job?> UpdateAsync(Job job) => _repository.UpdateAsync(job);
        public Task<bool> DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
