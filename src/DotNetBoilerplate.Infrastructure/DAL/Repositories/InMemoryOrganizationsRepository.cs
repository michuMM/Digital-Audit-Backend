using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Organizations.Exceptions;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryOrganizationsRepository : IOrganizationsRepository
{
    private readonly List<Organization> organizations = [];


    public Task<Organization> GetByIdAsync(Guid id)
    {
        var organization = organizations.Find(x => x.Id == id);

        return Task.FromResult(organization);
    }

    public Task<List<Organization>> GetAllAsync()
    {
        return Task.FromResult(organizations);
    }

    public Task AddAsync(Organization organization)
    {
        organizations.Add(organization);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Organization organization)
    {
        var existingOrganization = organizations.FirstOrDefault(x => x.Id == organization.Id);

        if (existingOrganization == null)
        {
            throw new OrganizationNotFoundException();
        }

        existingOrganization.Name = organization.Name;        

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Organization organization)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsOrganizationNameUniqueAsync(string name, Guid id)
    {
        var isNameUnique = organizations
            .Where(x => x.Id != id)
            .All(x => x.Name != name);

        return Task.FromResult(isNameUnique);
    }
}