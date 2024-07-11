using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Core.Organizations;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;
internal static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, PostgresUserRepository>();

        services.AddSingleton<IOrganizationsRepository, InMemoryOrganizationsRepository>();

        return services;
    }
}