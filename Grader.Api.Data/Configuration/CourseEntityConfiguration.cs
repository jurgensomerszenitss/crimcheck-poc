using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.Configuration
{
    internal class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            /// table
            builder.ToTable("course").HasKey(p => p.Id);

            /// properties
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(4000);

            // relations
            builder.HasOne(p => p.Category).WithMany(p => p.Courses).HasForeignKey(p => p.CategoryId);
        }
    }
}
