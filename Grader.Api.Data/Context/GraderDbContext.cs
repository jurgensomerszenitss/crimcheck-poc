using Grader.Api.Data.Model;
using Grader.Api.Data.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Grader.Api.Data.Context
{
    public class GraderDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
      
        public GraderDbContext(DbContextOptions<GraderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.BuildCategoryModel()
                        .BuildCourseModel()
                        .BuildLessonModel();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention(); 
        }

        public void Verify()
        {
#if DEBUG
            try
            {
                var pendingMigrations = Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                    //pendingMigrations.ToList().ForEach(m => Log.Information("Applying database migration {0}", m));
                    Database.Migrate();
                }
                else
                {
                    //Log.Information("No migrations needed, database is up to date");
                }

            }
            catch (Exception exc)
            {
                //Log.Fatal(exc, "Database migration failed");
            }

#endif
        }
    }
}
