using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticelAgg;
using BlogManagement.Domain.ArticelCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogManagement.Infrastructure.EFCore
{
    public class ArticelContext:DbContext
    {
        public ArticelContext(DbContextOptions<ArticelContext> options):base(options)
        {
            
        }

        public DbSet<ArticelCategory> ArticelCategories { get; set; }
        public DbSet<Articel> Articels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticelContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
