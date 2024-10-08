using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticelCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticelCategoryMapping:IEntityTypeConfiguration<ArticelCategory>
    {
        public void Configure(EntityTypeBuilder<ArticelCategory> builder)
        {
            builder.ToTable("ArticelCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.MetaDescription).HasMaxLength(200);
            builder.Property(x => x.Picture).HasMaxLength(200);
            builder.Property(x => x.PictureAlt).HasMaxLength(200);
            builder.Property(x => x.PictureTitle).HasMaxLength(200);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.Keywords).HasMaxLength(100);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasMany(x => x.Articels).WithOne(x => x.ArticelCategory).HasForeignKey(x => x.ArticelCategoryId);
        }
    }
}
