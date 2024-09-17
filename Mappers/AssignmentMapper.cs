using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Mappers
{
    public class AssignmentMapper
    {
        public static AssignmentEntity ToAssignmentEntity(AssignmentCreateDto assignment)
        {
            return new AssignmentEntity
            {
                Name = assignment.Name,
                Company = assignment.Company
            };
        }

        public static AssignmentDto ToAssignmentDto(AssignmentEntity assignment)
        {
            return new AssignmentDto
            {
                Id = assignment.Id,
                Name = assignment.Name ?? "",
                Company = assignment.Company ?? ""
            };
        }
    }
}