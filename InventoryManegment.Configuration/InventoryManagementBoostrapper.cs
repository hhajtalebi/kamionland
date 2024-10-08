using _0_Framework.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.InventoryApplication;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using InventoryManegment.Configuration.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManegment.Configuration
{
    public class InventoryManagementBoostrapper
    {
        public static void ConfigurInventory(IServiceCollection services, string contectionString)
        {

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryApplication, InventoryApplication>();

            services.AddScoped<IPermissionExposer, InventoryPermissionExposer>();

            //services.AddScoped<IInventoryQuery, InventoryQuery>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(contectionString));
        }
    }
}
