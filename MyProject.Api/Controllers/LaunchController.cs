using Microsoft.AspNetCore.Mvc;
using MyProject.Infrastructure.Services;
using MyProject.Domain.Entities;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchController : ControllerBase
    {
        private readonly SpaceXService _spaceXService;

        public LaunchController(SpaceXService spaceXService)
        {
            _spaceXService = spaceXService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Launch>>> GetLaunches()
        {
            var launches = await _spaceXService.GetLaunchesAsync();
            return Ok(launches);
        }
    }
}
