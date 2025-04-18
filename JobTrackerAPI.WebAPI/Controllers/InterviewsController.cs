using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewsController(IInterviewService interviewService){
            _interviewService = interviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterviews(){
            var interviews = await _interviewService.GetAllAsync();

            var result = interviews.Select(i => new
            {
                _id = i.Id,
                i.Title,
                i.Datetime,
                i.CreatedAt,
                i.JobAdvertisementId,
                Advertiser = i.Job?.Advertiser
            });

            var formatted = new
            {
                interviews = result
            };


            return Ok(formatted);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInterview([FromBody] InterviewDto dto)
        {
            var interview = new Interview
            {
                Title = dto.Title,
                Datetime = dto.Datetime,
                JobAdvertisementId = dto.JobAdvertisementId,
                CreatedAt = DateTime.UtcNow
            };


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
