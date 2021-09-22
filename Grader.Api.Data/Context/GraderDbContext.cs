using Grader.Api.Data.Configuration;
using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;
using Serilog;
using System;
using System.Linq;

namespace Grader.Api.Data.Context
{
    public class GraderDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Media> Media { get; set; }

        public GraderDbContext(DbContextOptions<GraderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration())
                .ApplyConfiguration(new CourseEntityConfiguration())
                .ApplyConfiguration(new LessonEntityConfiguration())
                .ApplyConfiguration(new MediaEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();            

            optionsBuilder.ReplaceService<IMigrationsSqlGenerator, ExtendedNpgsqlMigrationsSqlGenerator>();
        }

        public void Verify()
        {
#if DEBUG
            try
            {
                var pendingMigrations = Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                    Database.Migrate();
                    Log.Information("Database migrated");
                }
            }
            catch(Exception exc)
            {
                Log.Error(exc, "Error migrating database");
            }

#endif
        }
    }
}
