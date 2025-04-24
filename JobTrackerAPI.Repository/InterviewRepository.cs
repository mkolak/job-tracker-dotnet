using AutoMapper;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Repository.Data;
using JobTrackerAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Repository
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InterviewRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Interview>> GetAllAsync() {
            var interviews = await _context.Interviews
                .Include(i => i.Job)
                .OrderByDescending(i => i.Datetime)
                .ToListAsync();
            return _mapper.Map<IEnumerable<Interview>>(interviews);
        }

        public async Task<Interview?> GetByIdAsync(Guid id) {
            var entity = await _context.Interviews
                .Include(i => i.Job)
                .FirstOrDefaultAsync(i => i.Id == id);
            return _mapper.Map<Interview>(entity);
        }

        public async Task<Interview> CreateAsync(Interview interview) {
            var entity = _mapper.Map<InterviewEntity>(interview);
            _context.Interviews.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Interview>(entity);
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
