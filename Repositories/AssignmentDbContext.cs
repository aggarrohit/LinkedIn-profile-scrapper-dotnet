using LinkedinScrapper.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkedinScrapper.Repositories
{
    public class AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : DbContext(options)
    {
        public DbSet<AssignmentEntity> Assignments { get; set; } = null!;
    }
}