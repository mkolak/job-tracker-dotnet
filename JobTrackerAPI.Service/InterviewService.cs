using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Service.Common;

namespace JobTrackerAPI.Service
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _repository;

        public InterviewService(IInterviewRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Interview>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Interview?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task<Interview> CreateAsync(Interview interview) => _repository.CreateAsync(interview);

        public Task<bool> DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}