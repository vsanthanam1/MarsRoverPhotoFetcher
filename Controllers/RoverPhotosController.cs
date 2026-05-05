using MarsRoverPhotoFetcher.Services.Implementations;
using MarsRoverPhotoFetcher.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverPhotoFetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverPhotosController : ControllerBase
    {
        private readonly IRoverJobService _jobService;
        public RoverPhotosController(IRoverJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("photos")]
        public async Task<IActionResult> GetPhotos()
        {

            var results = await _jobService.RunAsync();
            return Ok(results);
        }


    }
}
