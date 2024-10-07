using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrucksManagement.Domain.TruckAgg;
using TrucksManagement.Domain.TruckCategoryAgg;
using TrucksManagement.Domain.TruckPictureAgg;
using TrucksManagement.Infrustructuer.EfCore.Mapping;

namespace TrucksManagement.Infrustructuer.EfCore
{
    public class TrcksContext:DbContext
    {
        public TrcksContext(DbContextOptions<TrcksContext> options):base(options)
        {
            
        }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckCategory> TruckCategories { get; set; }
        public DbSet<TruckPicture> TruckPicture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asembly = typeof(TrucksMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
