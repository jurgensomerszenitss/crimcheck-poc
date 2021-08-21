using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Grader.Api.Data.Context
{

    public class GraderDbContextFactory : IDesignTimeDbContextFactory<GraderDbContext>
    {
        public GraderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GraderDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=grader; user id=postgres; password=zenitss");

            return new GraderDbContext(optionsBuilder.Options);
        }
    }
}
