namespace LinkedinScrapper.Entities
{
    public class ScrappedDataEntity
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
    }
}