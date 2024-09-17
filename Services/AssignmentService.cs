using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;
using LinkedinScrapper.Mappers;
using LinkedinScrapper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinScrapper.Services
{

    public class AssignmentService(IAssignmentRepository assignmentRepository)
    {

        IAssignmentRepository _assignmentRepository = assignmentRepository;

        public List<AssignmentDto> Get()
        {
            List<AssignmentEntity> assignments = [.. _assignmentRepository.GetAll()];
            return assignments.Select(AssignmentMapper.ToAssignmentDto).ToList();
        }

        public AssignmentEntity? GetById(int id)
        {
            return _assignmentRepository.GetById(id);
        }

        public ActionResult<AssignmentDto> Add(AssignmentCreateDto assignment)
        {
            return AssignmentMapper.ToAssignmentDto(_assignmentRepository.Add(AssignmentMapper.ToAssignmentEntity(assignment)));
        }

        [HttpDelete]
        public bool Delete([FromQuery] int id)
        {
            _assignmentRepository.Delete(id);
            return true;
        }

        public AssignmentDto Update(int id, AssignmentCreateDto assignment)
        {
            try
            {
                AssignmentEntity updatedAssignment = _assignmentRepository.Update(id, AssignmentMapper.ToAssignmentEntity(assignment));
                return AssignmentMapper.ToAssignmentDto(updatedAssignment);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}