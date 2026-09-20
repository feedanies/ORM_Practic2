using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORM_Practic2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.Data.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(b => b.Genre)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);
        }
    }
}
