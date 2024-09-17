using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Mappers
{
    public class AssignmentCreateMapper
    {
        public static AssignmentEntity Map(AssignmentCreateDto assignment)
        {
            return new AssignmentEntity
            {
                Name = assignment.Name,
                Company = assignment.Company
            };
        }
    }
}