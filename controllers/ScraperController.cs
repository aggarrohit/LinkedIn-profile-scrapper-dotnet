using LinkedinScrapper.Dtos;
using LinkedinScrapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ScraperController : ControllerBase
    {
         private readonly Scraper _scraper; // Private readonly for the injected dependency

        // Constructor for dependency injection
        public ScraperController(Scraper scraper)
        {
            _scraper = scraper; // Assign the injected service to the private field
        }

        [HttpPost]
        public ActionResult AddLinkedinLinks([FromBody] AssignmentLinksDto assignmentLinksDto)
        {
            var data = _scraper.ScrapeLinkedInProfile(assignmentLinksDto);
            return Ok(
                new
                {
                    assignmentId= assignmentLinksDto.AssignmentId,
                    scrappedData = data
                }
            );
        }
    }
}