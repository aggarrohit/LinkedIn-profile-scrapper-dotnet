

using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Repositories
{
    public class AssignmentRepository(AssignmentDbContext dbContext) : IAssignmentRepository
    {
        private readonly AssignmentDbContext _dbContext = dbContext;

        public AssignmentEntity Add(AssignmentEntity item)
        {
            // Add the item to the database and return the item with the id
            var entity = _dbContext.Assignments.Add(item);
            _dbContext.SaveChanges();
            return entity.Entity;

        }

        public void Delete(int id)
        {
            var item = _dbContext.Assignments.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _dbContext.Assignments.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<AssignmentEntity> GetAll()
        {
            return _dbContext.Assignments;
        }

        public AssignmentEntity GetById(int id)
        {
            var existingItem = _dbContext.Assignments.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                return existingItem;
            }
            throw new Exception("Assignment not found");
        }

        public AssignmentEntity Update(int id, AssignmentEntity item)
        {
            var existingItem = _dbContext.Assignments.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Company = item.Company;
                _dbContext.SaveChanges();
                return existingItem;
            }
            throw new Exception("Assignment not found");
            
        }
    }
}
