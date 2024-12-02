using NTT.CafeManagement.Application.Commands.Employee;
using NTT.CafeManagement.Application.Validators;

namespace NTT.CafeManagement.Application.IoC;

public static class ApplicationDependencyModule
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<CreateEmployeeCommand>, CreateEmployeeCommandValidator>();
        services.AddSingleton<IValidator<UpdateEmployeeCommand>, UpdateEmployeeCommandValidator>();
    }
}
