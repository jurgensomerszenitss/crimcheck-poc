using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Grader.Api.Data.Configuration
{
    internal class LessonEntityConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            /// table
            builder.ToTable("lesson").HasKey(p => p.Id);

            /// properties
            builder.Property(p => p.Topic).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(4000);

            // relations
            builder.HasOne(p => p.Course).WithMany(p => p.Lessons).HasForeignKey(p => p.CourseId);
        }
    }
}
