using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrucksManagement.Application;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Application.contracts.TrkPictureApplication;
using TrucksManagement.Application.contracts.TrucksApplication;
using TrucksManagement.Domain.TruckAgg;
using TrucksManagement.Domain.TruckCategoryAgg;
using TrucksManagement.Domain.TruckPictureAgg;
using TrucksManagement.Infrustructuer.EfCore;
using TrucksManagement.Infrustructuer.EfCore.Repository;

namespace TrucksManagement.Configuration
{
     public class TrucksManagementBoostrapper
    {
        public static void Configur(IServiceCollection services, string contectionString)
        {
            services.AddScoped<ITrkCategoryApplication, TrkCategoryApplication>();
            services.AddScoped<ITrkPictureApplication, TrkPictureApplication>();
            services.AddScoped<ITrucksApplication, TrucksApplication>();

            services.AddScoped<ITruckCategoryRepository, TrkCategoryRepository>();
            services.AddScoped<ITruckPictureRepository, TrkPictureRepository>();
            services.AddScoped<ITruckRepository, TruckRepository>();

            services.AddDbContext<TrcksContext>(x => x.UseSqlServer(contectionString));
           
        }
    }
}
