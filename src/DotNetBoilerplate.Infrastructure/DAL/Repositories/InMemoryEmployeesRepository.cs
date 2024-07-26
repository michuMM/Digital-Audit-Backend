using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Users;
using DotNetBoilerplate.Core.Employees.Exceptions;

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
        var existingEmployee = employees.FirstOrDefault(x => x.Id == employee.Id);

        if (existingEmployee == null) 
        {
            throw new EmployeeNotFoundException();
        }

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Email = employee.Email;
        existingEmployee.Phone = employee.Phone;

        return Task.CompletedTask;
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