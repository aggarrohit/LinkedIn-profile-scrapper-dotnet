using LinkedinScrapper.Entities;
using LinkedinScrapper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.Services
{
    
    public class AssignmentService(IAssignmentRepository assignmentRepository)
    {

        IAssignmentRepository _assignmentRepository = assignmentRepository;

        public List<AssignmentEntity> Get()
        {
            List<AssignmentEntity> assignments = [.. _assignmentRepository.GetAll()];
            return assignments;
        }

        public AssignmentEntity GetById(int id)
        {
            return _assignmentRepository.GetById(id);
        }

        public ActionResult<AssignmentEntity> Add(AssignmentEntity assignment)
        {
            return  _assignmentRepository.Add(assignment);
        }

        [HttpDelete]
        public bool Delete([FromQuery] int id)
        {
            _assignmentRepository.Delete(id);
            return true;
        }

        public AssignmentEntity Update(int id, AssignmentEntity assignment)
        {
            try
            {
                AssignmentEntity updatedAssignment = _assignmentRepository.Update(id, assignment);
                return updatedAssignment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}