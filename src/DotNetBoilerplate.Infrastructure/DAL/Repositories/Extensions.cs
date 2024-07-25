using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Faults;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;
internal static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, PostgresUserRepository>();        

        services.AddSingleton<IOrganizationsRepository, InMemoryOrganizationsRepository>();
        services.AddSingleton<IDevicesRepository, InMemoryDevicesRepository>();
        services.AddSingleton<IFaultsRepository, InMemoryFaultsRepository>();
        services.AddSingleton<IEmployeesRepository, InMemoryEmployeesRepository>();
        return services;
    }
}