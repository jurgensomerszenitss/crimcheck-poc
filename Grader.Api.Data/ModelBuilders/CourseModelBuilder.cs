using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.ModelBuilders
{
    public static class CourseModelBuilder
    {
        internal static ModelBuilder BuildCourseModel(this ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<Course>();

            entityTypeBuilder.ToTable("course").HasKey(p => p.Id);

            entityTypeBuilder.MapProperties()
                             .MapRelations();

            return modelBuilder;
        }

        private static EntityTypeBuilder<Course> MapProperties(this EntityTypeBuilder<Course> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(p => p.Description).IsRequired().HasMaxLength(4000);


            return entityTypeBuilder;
        }


        private static EntityTypeBuilder<Course> MapRelations(this EntityTypeBuilder<Course> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(p => p.Category).WithMany(p => p.Courses).HasForeignKey(p => p.CategoryId);
            return entityTypeBuilder;
        }
    }
}
