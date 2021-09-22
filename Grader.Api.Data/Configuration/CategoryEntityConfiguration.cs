using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.Configuration
{
    internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    { 
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            /// table
            builder.ToTable("category").HasKey(p => p.Id);

            /// properties
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.SearchText).ValueGeneratedOnAdd();
            builder.Property(p => p.ImageId).IsRequired(false);

            // relations
            builder.HasOne(p => p.Image).WithMany().HasForeignKey(p => p.ImageId);
        }
    }
}
