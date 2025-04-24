using AutoMapper;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Service.Common;
using JobTrackerAPI.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        private readonly IMapper _mapper;

        public InterviewsController(IInterviewService interviewService, IMapper mapper)
        {
            _interviewService = interviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterviews(){
            var interviews = await _interviewService.GetAllAsync();

            var interviewDtos = _mapper.Map<IEnumerable<InterviewResponseDto>>(interviews);

            return Ok(new { interviews = interviewDtos });
        }

        [HttpPost]
        public async Task<IActionResult> CreateInterview([FromBody] InterviewRequestDto interviewRequestDto)
        {
            var interview = _mapper.Map<Interview>(interviewRequestDto);
            var created = await _interviewService.CreateAsync(interview);
            return Ok(new { 
                interview = created
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(Guid id){
            var success = await _interviewService.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok(new { msg = "Success" });
        }
    }
}
