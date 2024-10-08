using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping:IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Invevntories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Size).HasMaxLength(200);
            builder.Property(x => x.Color).HasMaxLength(200);
            builder.Property(x => x.Weight).HasMaxLength(200);

            builder.OwnsMany(x => x.OpertionList, ModelBuilder =>
            {
                ModelBuilder.HasKey(x => x.Id);
                ModelBuilder.ToTable("InventoryOpertiones");

                ModelBuilder.Property(x => x.Description).HasMaxLength(1000);
              
                ModelBuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });
        }
    }
}
