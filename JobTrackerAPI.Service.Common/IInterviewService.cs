using JobTrackerAPI.Model.Entities;

namespace JobTrackerAPI.Service.Common
{
    public interface IInterviewService
    {
        Task<IEnumerable<Interview>> GetAllAsync();
        Task<Interview?> GetByIdAsync(Guid id);
        Task<Interview> CreateAsync(Interview interview);
        Task<bool> DeleteAsync(Guid id);
    }
}