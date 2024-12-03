using NTT.CafeManagement.Application.Infrastructure.MediatR;
using NTT.CafeManagement.Application.IoC;

namespace NTT.CafeManagement.IoC;

public static class ApiDependencyModule
{
    public static void RegisterApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationDependencyModule));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });
    }
}
