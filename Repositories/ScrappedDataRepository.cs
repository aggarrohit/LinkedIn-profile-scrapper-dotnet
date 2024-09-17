using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Repositories
{
    public class ScrappedDataRepository(AssignmentDbContext dbContext) : IScrappedDataRepository
    {
        private readonly AssignmentDbContext _dbContext = dbContext;

        public ScrappedDataEntity Add(ScrappedDataEntity item)
        {
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
