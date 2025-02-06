using Microsoft.AspNetCore.Mvc;
using YouTubeApi._2.Application.Interfaces;

namespace YouTubeApi._1.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IYouTubeService _youTubeService;

        public VideosController(IYouTubeService youTubeService)
        {
            _youTubeService = youTubeService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchVideos([FromQuery] string query, [FromQuery] DateTime publishedAfter)
        {
            var videos = await _youTubeService.SearchVideosAsync(query, publishedAfter);
            return Ok(videos);
        }
    }
}
