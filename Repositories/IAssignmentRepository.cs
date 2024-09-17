using LinkedinScrapper.Dtos;
using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Repositories
{
    public interface IAssignmentRepository
    {
        AssignmentEntity Add(AssignmentCreateDto item);
        void Delete(int id);
        AssignmentEntity Update(int id, AssignmentEntity item);
        IQueryable<AssignmentEntity> GetAll();

        AssignmentEntity? GetById(int id);
    }
}