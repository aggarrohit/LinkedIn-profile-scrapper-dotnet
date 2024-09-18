
namespace LinkedinScrapper.Dtos
{
    public class AssignmentLinksDto
    {
        public required int AssignmentId { get; set; }
        public required List<string> Links { get; set; }
    }
}