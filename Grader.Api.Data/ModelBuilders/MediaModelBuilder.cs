using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.ModelBuilders
{
    public static class MediaModelBuilder
    {
        internal static ModelBuilder BuildMediaModel(this ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<Media>();

            entityTypeBuilder.ToTable("media").HasKey(p => p.Id);

            entityTypeBuilder.MapProperties();

            return modelBuilder;
        }

        private static EntityTypeBuilder<Media> MapProperties(this EntityTypeBuilder<Media> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Key).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(p => p.Content).IsRequired();

            return entityTypeBuilder;
        }
         
    }
}
