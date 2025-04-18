using Microsoft.AspNetCore.Mvc;
using JobTrackerAPI.Repository.Data;

namespace JobTrackerAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DbHealthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DbHealthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Check()
        {
            var canConnect = _context.Database.CanConnect();
            return Ok(new { status = canConnect ? "Connected" : "Disconnected" });
        }
    }
}
