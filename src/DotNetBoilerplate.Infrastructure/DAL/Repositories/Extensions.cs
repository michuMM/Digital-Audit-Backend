using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Employees;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;
internal static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, PostgresUserRepository>();

        services.AddSingleton<IOrganizationsRepository, InMemoryOrganizationsRepository>();

        services.AddSingleton<IEmployeesRepository, InMemoryEmployeesRepository>();
        return services;
    }
}