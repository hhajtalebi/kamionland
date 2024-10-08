using _0_Framework.Infrastructure;
using blogManagement.Application.Contracts.ArticelCategoryApplication;
using BlogManagement.Application;
using blogManagement.Application.Contracts.ArticelApplication;
using BlogManagement.Configuration.Permission;
using BlogManagement.Domain.ArticelAgg;
using BlogManagement.Domain.ArticelCategoryAgg;
using BlogManagement.Infrastructure.EFCore;
using BlogManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Configuration
{
    public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IArticelCategoryRepository, ArticelCategoryRepository>();
            services.AddScoped<IAricelCategoryApplication, ArticelCategoryApplication>();

            services.AddScoped<IArticelRepository, ArticelRepository>();
            services.AddScoped<IArticelApplication, ArticelApplication>();

            services.AddScoped<IPermissionExposer, BlogPermissionExposer>();

            services.AddDbContext<ArticelContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
