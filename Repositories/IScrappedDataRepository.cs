using LinkedinScrapper.Entities;

namespace LinkedinScrapper.Repositories
{
    public interface IScrappedDataRepository
    {
        ScrappedDataEntity Add(ScrappedDataEntity item);

        // get all scrapped data entries for a specific assignment
        IQueryable<ScrappedDataEntity> GetAll(int assignmentId);
    }
}