using LinkedinScrapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            Scraper scraper = new Scraper();
            scraper.ScrapeLinkedInProfile("https://www.linkedin.com/in/rohit-agarwal-b13a5016/");
            return Ok("1.0");
        }
    }
}