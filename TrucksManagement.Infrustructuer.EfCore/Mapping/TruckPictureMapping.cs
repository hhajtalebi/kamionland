using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrucksManagement.Domain.TruckPictureAgg;

namespace TrucksManagement.Infrustructuer.EfCore.Mapping
{
    public class TruckPictureMapping:IEntityTypeConfiguration<TruckPicture>
    {
        public void Configure(EntityTypeBuilder<TruckPicture> builder)
        {
            builder.ToTable("TruckPicture");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureTitel).HasMaxLength(500);
            builder.Property(x => x.PictureAlte).HasMaxLength(500);

            builder.HasOne(x => x.Truck).WithMany(x => x.TruckPictures).HasForeignKey(x => x.TruckId);



        }
    }
}
