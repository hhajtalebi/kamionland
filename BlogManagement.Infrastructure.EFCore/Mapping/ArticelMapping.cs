using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticelAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticelMapping : IEntityTypeConfiguration<Articel>
    {
        public void Configure(EntityTypeBuilder<Articel> builder)
        {
            builder.ToTable("Articels");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.MetaDescription).HasMaxLength(200);
            builder.Property(x => x.Picture).HasMaxLength(200);
            builder.Property(x => x.PictureAlte).HasMaxLength(200);
            builder.Property(x => x.PictureTitle).HasMaxLength(200);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.Keywords).HasMaxLength(100);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasOne(x => x.ArticelCategory).WithMany(x => x.Articels).HasForeignKey(x => x.ArticelCategoryId);
        }
    }
}
