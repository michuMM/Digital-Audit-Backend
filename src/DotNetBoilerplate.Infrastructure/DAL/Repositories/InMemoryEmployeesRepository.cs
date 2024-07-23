using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Users;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

internal sealed class InMemoryEmployeesRepository : IEmployeesRepository
{
    private readonly List<Employee> employees = [];


    public Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = employees.Find(x => x.Id == id);

        return Task.FromResult(employee);
    }

    public Task<List<Employee>> GetAllAsync()
    {
        return Task.FromResult(employees);
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

    public async Task DeleteAsync(Employee employee)
    {
        employees.Remove(employee);
        await Task.CompletedTask;
    }

    public Task<bool> IsEmployeeEmailUniqueAsync(string email, Guid id)
    {
        var isEmailUnique = employees
            .Where(x => x.Id !=  id)
            .All(x => x.Email == email);

        return Task.FromResult(isEmailUnique);
    }

    public Task<bool> IsEmployeePhoneUniqueAsync(string phone, Guid id)
    {
        var isPhoneUnique = employees
            .Where(x => x.Id !=  id)
            .All(x => x.Phone == phone);

        return Task.FromResult(isPhoneUnique);
    }
}