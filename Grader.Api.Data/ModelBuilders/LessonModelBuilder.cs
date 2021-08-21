using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.ModelBuilders
{
    public static class LessonModelBuilder
    {
        internal static ModelBuilder BuildLessonModel(this ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<Lesson>();

            entityTypeBuilder.ToTable("lesson").HasKey(p => p.Id);

            entityTypeBuilder.MapProperties()
                             .MapRelations();

            return modelBuilder;
        }

        private static EntityTypeBuilder<Lesson> MapProperties(this EntityTypeBuilder<Lesson> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Topic).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(p => p.Description).IsRequired().HasMaxLength(4000);


            return entityTypeBuilder;
        }


        private static EntityTypeBuilder<Lesson> MapRelations(this EntityTypeBuilder<Lesson> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(p => p.Course).WithMany(p => p.Lessons).HasForeignKey(p => p.CourseId);

            return entityTypeBuilder;
        }
    }
}
