using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;
        
        public TestController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pgNumber, int pgSize)
        {
           return Ok(await _hackerNewsService.GetLatestStories(pgNumber, pgSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Search(string term, int pgNumber, int pgSize)
        {
            return Ok(await _hackerNewsService.SearchLatestStories(term, pgNumber, pgSize));
        }

    }
}