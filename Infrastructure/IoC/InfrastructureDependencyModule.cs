using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTT.CafeManagement.Infrastructure.Database;

namespace NTT.CafeManagement.Infrastructure.IoC
{
    public static class InfrastructureDependencyModule
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("Database"));

            services.AddScoped<ICafeManagementDbContext, CafeManagementDbContext>();
        }
    }
}
