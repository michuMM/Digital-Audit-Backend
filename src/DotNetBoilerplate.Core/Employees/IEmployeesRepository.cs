namespace DotNetBoilerplate.Core.Employees;

public interface IEmployeesRepository
{
    Task<Employee?> GetByIdAsync(Guid id);
    
    Task AddAsync(Employee employee);
    
    Task UpdateAsync(Employee employee);
    
    Task DeleteAsync(Guid id);

    Task<bool> IsEmployeeEmailUniqueAsync(string email, Guid id);

    Task<bool> IsEmployeePhoneUniqueAsync(string phone, Guid id);
}
