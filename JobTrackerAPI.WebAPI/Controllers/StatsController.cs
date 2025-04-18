using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService){
            _statsService = statsService;
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetJobLocations([FromQuery] JobQueryParameters query)
        {
            var result = await _statsService.GetJobsByLocationAsync(query);

            var formatted = new
            {
                locations = result.Select(r => new
                {
                    _id = r.Location,
                    r.Count
                })
            };

            return Ok(formatted);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetJobStatusCounts([FromQuery] JobQueryParameters query)
        {
            var result = await _statsService.GetJobsByStatusAsync(query);

            var formatted = new
            {
                status = result.Select(r => new
                {
                    _id = r.Status,
                    r.Count
                })
            };

            return Ok(formatted);
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetJobsPerMonth(){
            var result = await _statsService.GetJobsPerMonthAsync();

            var formatted = new
            {
                stats = result
            };

            return Ok(formatted);
        }

    }
}
