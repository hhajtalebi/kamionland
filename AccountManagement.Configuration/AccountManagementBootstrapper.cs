using _0_Framework.Infrastructure;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.AccountApplication;
using AccountManagement.Application.Contracts.RoleApplication;
using AccountManagement.Configuration.Permission;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountMangement.Infrastructure.EFCore;
using AccountMangement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddScoped<IPermissionExposer, AccountPermissionExposer>();
            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
