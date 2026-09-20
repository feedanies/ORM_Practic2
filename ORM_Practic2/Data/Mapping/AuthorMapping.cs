using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORM_Practic2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Practic2.Data.Mapping
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Fullname)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            builder.Property(a => a.Age)
                .IsRequired(true);
            builder.HasCheckConstraint("Author_Age", "[Age]>0");

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired(true);

        }
    }
}
