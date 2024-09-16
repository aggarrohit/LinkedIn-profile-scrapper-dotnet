using LinkedinScrapper.Entities;
using LinkedinScrapper.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AssignmentController(IAssignmentRepository assignmentRepository) : ControllerBase
    {

        IAssignmentRepository _assignmentRepository = assignmentRepository;

        [HttpGet]
        public ActionResult Get()
        {
            List<AssignmentEntity> assignments = [.. _assignmentRepository.GetAll()];
            return Ok(new
                {
                    assignments = assignments
                }
            );
        }

        [HttpPost]
        public ActionResult<AssignmentEntity> Add([FromBody] AssignmentEntity assignment)
        {
            return Ok(
                new
                {
                    assignment = _assignmentRepository.Add(assignment)
                }
            );
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            _assignmentRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update( [FromQuery]
            int id, AssignmentEntity assignment)
        {
            try
            {
                AssignmentEntity updatedAssignment = _assignmentRepository.Update(id, assignment);
                return Ok(updatedAssignment);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}