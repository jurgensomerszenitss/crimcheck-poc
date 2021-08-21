using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.ModelBuilders
{
    public static class CategoryModelBuilder
    {
        internal static ModelBuilder BuildCategoryModel(this ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<Category>();

            entityTypeBuilder.ToTable("category").HasKey(p => p.Id);

            entityTypeBuilder.MapProperties()
                             .MapRelations();

            return modelBuilder;
        }

        private static EntityTypeBuilder<Category> MapProperties(this EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            return entityTypeBuilder;
        }


        private static EntityTypeBuilder<Category> MapRelations(this EntityTypeBuilder<Category> entityTypeBuilder)
        { 
            return entityTypeBuilder;
        }
    }
}
