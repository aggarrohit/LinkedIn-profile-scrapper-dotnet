using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;
using LinkedinScrapper.Repositories;
using LinkedinScrapper.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AssignmentController(AssignmentService assignmentService) : ControllerBase
    {

        // IAssignmentRepository _assignmentRepository = assignmentRepository;

        [HttpGet]
        public ActionResult Get()
        {
            List<AssignmentDto> assignments = assignmentService.Get();
            return Ok(new
                {
                    assignments = assignments
                }
            );
        }

        [HttpPost]
        public ActionResult Add([FromBody] AssignmentCreateDto assignment)
        {
            return Ok(
                new
                {
                    assignment = assignmentService.Add(assignment).Value
                }
            );
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            assignmentService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update( [FromQuery]
            int id, AssignmentCreateDto assignment)
        {
            try
            {
                AssignmentDto updatedAssignment = assignmentService.Update(id, assignment);
                return Ok(updatedAssignment);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}