using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Repositories
{
    public interface IScrappedDataRepository
    {
        ScrappedDataEntity Add(ScrappedDataEntity item);

        IQueryable<ScrappedDataEntity> GetAll(int assignmentId);
    }
}