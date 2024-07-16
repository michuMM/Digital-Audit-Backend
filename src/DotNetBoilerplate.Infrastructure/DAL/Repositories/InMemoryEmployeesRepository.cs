using DotNetBoilerplate.Core.Employees;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryEmployeesRepository : IEmployeesRepository
{
    private readonly List<Employee> employees = [];


    public Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = employees.Find(x => x.Id == id);

        return Task.FromResult(employee);
    }

    public Task AddAsync(Employee employee)
    {
        employees.Add(employee);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmployeeEmailUniqueAsync(string email, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmployeePhoneUniqueAsync(string phone, Guid id)
    {
        throw new NotImplementedException();
    }
}