using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs([FromQuery] JobQueryParameters query) {
            var (jobs, totalCount) = await _jobService.GetAllAsync(query);

            var result = new
            {
                jobs = jobs.Select(j => new
                {
                    _id = j.Id,
                    j.Advertisement,
                    j.Advertiser,
                    j.AdvertiserWebsite,
                    j.Location,
                    j.AdvertisementUrl,
                    j.Status,
                    j.CreatedAt,
                    j.AppliedAt,
                    Interviews = j.Interviews.Select(i => new
                    {
                        _id = i.Id,
                        i.Title,
                        i.Datetime,
                        i.CreatedAt,
                        i.JobAdvertisementId
                    })
                }),
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

            var result = new
            {
                _id = job.Id,
                job.Id,
                job.Advertisement,
                job.Advertiser,
                job.AdvertiserWebsite,
                job.Location,
                job.AdvertisementUrl,
                job.Status,
                job.CreatedAt,
                job.AppliedAt,
                Interviews = job.Interviews.Select(i => new
                {
                    _id = i.Id,
                    i.Title,
                    i.Datetime,
                    i.CreatedAt,
                    i.JobAdvertisementId
                })
            };

            return Ok(new { 
                job = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(Job job) { 
            var created = await _jobService.CreateAsync(job);
            return Ok(created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateJob(Guid id,[FromBody] Job job) {
            job.Id = id;
            var updated = await _jobService.UpdateAsync(job);
            if (updated == null) return NotFound();

            return Ok(new { 
                job = updated
            });
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
