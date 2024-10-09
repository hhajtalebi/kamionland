using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SlideManagement.Applicaion;
using SlideManagement.Applicaion.Contracts.SlideApplication;
using SlideManagement.Domain.SlideAgg;
using SlideManagement.Infrastucture.Configuration.Permission;
using SlideManagement.Infrastucture.EfCore;
using SlideManagement.Infrastucture.EfCore.Repository;

namespace SlideManagement.Infrastucture.Configuration
{
    public class SlideManagementBoostrapper
    {
        public static void Configur(IServiceCollection services, string contectionString)
        {
            services.AddScoped<ISlideApplication, SlideApplication>();
            services.AddScoped<ISlideRepository, SlideRepository>();

          
            //services.AddScoped<ISlideQuery, SlideQuery>();

            services.AddTransient<IPermissionExposer, SlidePermissionExposer>();

            services.AddDbContext<SlideContext>(x => x.UseSqlServer(contectionString));
        }

    }
}
