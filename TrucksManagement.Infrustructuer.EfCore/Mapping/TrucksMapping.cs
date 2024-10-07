using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrucksManagement.Domain.TruckAgg;

namespace TrucksManagement.Infrustructuer.EfCore.Mapping
{
    internal class TrucksMapping:IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks");
            builder.HasKey(t => t.Id);


            builder.Property(x => x.ShortDescription).HasMaxLength(1500);
            builder.Property(x => x.color).HasMaxLength(200);
            builder.Property(x => x.PictureTitel).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.Slug).HasMaxLength(500);
            builder.Property(x => x.Keywords).HasMaxLength(500);

            builder.HasOne(x => x.Category).WithMany(x => x.Trucks).HasForeignKey(x => x.CategoryId);


            builder.HasMany(x => x.TruckPictures).WithOne(x => x.Truck).HasForeignKey(x => x.TruckId);
        }
    }
}
