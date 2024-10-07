using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrucksManagement.Domain.TruckCategoryAgg;

namespace TrucksManagement.Infrustructuer.EfCore.Mapping
{
    public class TruckCategoryMapping:IEntityTypeConfiguration<TruckCategory>
    {
        public void Configure(EntityTypeBuilder<TruckCategory> builder)
        {
            builder.ToTable("TruckCategories");
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Name).HasMaxLength(400);
            builder.Property(x => x.MetaDescription).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureTitel).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.Slug).HasMaxLength(500);

            builder.HasMany(x=>x.Trucks).WithOne(x=>x.Category).HasForeignKey(x=>x.Id);
        }
    }
}
