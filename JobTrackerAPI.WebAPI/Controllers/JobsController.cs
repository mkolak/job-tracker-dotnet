using AutoMapper;
using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Service.Common;
using JobTrackerAPI.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobsController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs([FromQuery] JobQueryParameters query) {
            var (jobs, totalCount) = await _jobService.GetAllAsync(query);

            var jobDtos = _mapper.Map<IEnumerable<JobResponseDto>>(jobs);

            var result = new
            {
                jobs = jobDtos,
                nbHits = totalCount,
                currentPage = query.Page,
                nextPage = (query.Page * query.Limit >= totalCount) ? (int?)null : query.Page + 1
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleJob(Guid id) { 
            var job = await _jobService.GetByIdAsync(id);  
            if (job == null) return NotFound();

            var jobDto = _mapper.Map<JobResponseDto>(job);
            return Ok(new { job = jobDto });
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobRequestDto jobRequestDto) {
            var job = _mapper.Map<Job>(jobRequestDto);
            var created = await _jobService.CreateAsync(job);
            var createdDto = _mapper.Map<JobResponseDto>(created);
            return Ok(new { job = createdDto });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateJob(Guid id, [FromBody] JobRequestDto jobRequestDto) {
            var job = _mapper.Map<Job>(jobRequestDto);
            job.Id = id;

            var updated = await _jobService.UpdateAsync(job);
            if (updated == null) return NotFound();

            var updatedDto = _mapper.Map<JobResponseDto>(updated);
            return Ok(new { job = updatedDto });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id) { 
            var success = await _jobService.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok(new { 
                msg = "Success"
            });
        }
    }
}
