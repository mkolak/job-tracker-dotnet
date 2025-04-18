using JobTrackerAPI.Model.Entities;

namespace JobTrackerAPI.Repository.Common
{
    public interface IInterviewRepository
    {
        Task<IEnumerable<Interview>> GetAllAsync();
        Task<Interview?> GetByIdAsync(Guid id);
        Task<Interview> CreateAsync(Interview interview);
        Task<bool> DeleteAsync(Guid id);
    }
}