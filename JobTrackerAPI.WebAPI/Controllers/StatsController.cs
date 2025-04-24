using AutoMapper;
using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Service.Common;
using JobTrackerAPI.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;
        private readonly IMapper _mapper;

        public StatsController(IStatsService statsService, IMapper mapper)
        {
            _statsService = statsService;
            _mapper = mapper;
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetJobLocations([FromQuery] JobQueryParameters query)
        {
            var result = await _statsService.GetJobsByLocationAsync(query);

            var dto = _mapper.Map<IEnumerable<LocationStatsResponseDto>>(result);
            return Ok(new { locations = dto });
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetJobStatusCounts([FromQuery] JobQueryParameters query)
        {
            var result = await _statsService.GetJobsByStatusAsync(query);

            var dto = _mapper.Map<IEnumerable<StatusStatsResponseDto>>(result);
            return Ok(new { status = dto });
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetJobsPerMonth(){
            var result = await _statsService.GetJobsPerMonthAsync();

            var dto = _mapper.Map<IEnumerable<MonthlyStatsResponseDto>>(result);
            return Ok(new { stats = dto });
        }

    }
}
