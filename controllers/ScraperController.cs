using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;
using LinkedinScrapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ScraperController(Scraper scraper, AssignmentService assignmentService) : ControllerBase
    {
        private readonly Scraper _scraper = scraper;
        private readonly AssignmentService _assignmentService = assignmentService;

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
                    assignment,
                    candidates = data
                }
            );
        }
    }
}