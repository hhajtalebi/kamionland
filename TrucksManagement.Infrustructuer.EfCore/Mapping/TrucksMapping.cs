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

        }
    }
}
