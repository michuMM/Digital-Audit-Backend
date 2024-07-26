using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Faults;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

public sealed class InMemoryFaultsRepository : IFaultsRepository
{
    private readonly List<Fault> faults = [];

    
    public Task<Fault> GetByIdAsync(Guid id)
    {
        var fault = faults.Find(x => x.Id == id);

        return Task.FromResult(fault);
    }

    public Task<List<Fault>> GetAllAsync()
    {
        return Task.FromResult(faults);
    }

    public Task AddAsync(Fault fault)
    {
        faults.Add(fault);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Fault fault)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Fault fault)
    {
        throw new NotImplementedException();
    }
}