using System;
using System.Collections.Generic;
using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grader.Api.Data.Configuration
{
    internal class MediaEntityConfiguration : IEntityTypeConfiguration<Media>
    {
        public MediaEntityConfiguration()
        {
        } 

        public void Configure(EntityTypeBuilder<Media> builder)
        {
            /// table
            builder.ToTable("media").HasKey(p => p.Id);

            /// properties
            builder.Property(p => p.Key).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Content).IsRequired(); 
        }
    }
}
