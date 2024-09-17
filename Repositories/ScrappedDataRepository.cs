

using LinkedinScrapper.Entities;
using LinkedinScrapper.Repositories;

namespace LinkedinScrapper.Repositories
{
    public class ScrappedDataRepository(AssignmentDbContext dbContext) : IScrappedDataRepository
    {
        private readonly AssignmentDbContext _dbContext = dbContext;

        public ScrappedDataEntity Add(ScrappedDataEntity item)
        {
            // Add the item to the database and return the item with the id
            var entity = _dbContext.ScrappedData.Add(item);
            _dbContext.SaveChanges();
            return entity.Entity;

        }

        public IQueryable<ScrappedDataEntity> GetAll(int assignmentId)
        {
            return _dbContext.ScrappedData.Where(x => x.AssignmentId == assignmentId);
        }

       
    }
}
