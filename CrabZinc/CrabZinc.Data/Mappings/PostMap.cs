using System;
using System.Collections.Generic;
using System.Text;
using CrabZinc.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwlTin.Common.Data;

namespace CrabZinc.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("POST")
                .HasKey(p => p.PostId);

            builder.Property(p => p.PostId)
                .HasColumnName("POST_ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PostUuid)
                .HasColumnName("UUID")
                .IsRequired();

            builder.Property(p => p.Slug)
                .HasColumnName("SLUG")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.Title)
                .HasColumnName("TITLE")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Content)
                .HasColumnName("CONTENT")
                .IsRequired();

            builder.Property(p => p.PublishedDate)
                .HasColumnName("PUBLISHED_DATE");

            builder.Property(p => p.Visible)
                .HasColumnName("VISIBLE");

            builder.AddTrackedEntityProperties();
            builder.AddActiveEntityProperties();
        }

    }
}
