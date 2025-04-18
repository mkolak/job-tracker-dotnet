using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly AppDbContext _context;

        public InterviewRepository(AppDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<Interview>> GetAllAsync() { 
            return await _context.Interviews
                .Include(i => i.Job)
                .OrderByDescending(i => i.Datetime)
                .ToListAsync();
        }

        public async Task<Interview?> GetByIdAsync(Guid id) {
            return await _context.Interviews
                .Include(i => i.Job)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Interview> CreateAsync(Interview interview) {
            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync();
            return interview;
        }

        public async Task<bool> DeleteAsync(Guid id) { 
            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null) return false;

            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
