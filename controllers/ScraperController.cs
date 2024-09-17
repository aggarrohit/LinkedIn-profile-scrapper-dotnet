using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;
using LinkedinScrapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ScraperController : ControllerBase
    {
         private readonly Scraper _scraper; // Private readonly for the injected dependency
         private readonly AssignmentService _assignmentService;

        // Constructor for dependency injection
        public ScraperController(Scraper scraper, AssignmentService assignmentService)
        {
            _scraper = scraper; // Assign the injected service to the private field
            _assignmentService = assignmentService;
        }

        [HttpPost]
        public ActionResult AddLinkedinLinks([FromBody] AssignmentLinksDto assignmentLinksDto)
        {
            AssignmentEntity assignment = _assignmentService.GetById(assignmentLinksDto.AssignmentId);
            if (assignment == null)
            {
                return NotFound("Assignment not found with the given id");
            }
            var data = _scraper.ScrapeLinkedInProfile(assignmentLinksDto);
            return Ok(
                new
                {
                    assignmentId= assignmentLinksDto.AssignmentId,
                    assignment = assignment,
                    scrappedData = data
                }
            );
        }
    }
}