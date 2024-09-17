
namespace LinkedinScrapper.Dtos
{
    public class AssignmentLinksDto
    {
        public required int AssignmentId { get; set; }
        // assignment links list
        public required List<string> Links { get; set; }
    }
}