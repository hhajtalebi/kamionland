using Microsoft.EntityFrameworkCore;
using SlideManagement.Domain.SlideAgg;
using SlideManagement.Infrastucture.EfCore.Mapping;


namespace SlideManagement.Infrastucture.EfCore
{
    public class SlideContext:DbContext
    {
        public SlideContext(DbContextOptions<SlideContext> options):base(options)
        {
            
        }

        public DbSet<Slide> Slides { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asembly = typeof(SlideMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
