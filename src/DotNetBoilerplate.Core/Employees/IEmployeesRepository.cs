﻿namespace DotNetBoilerplate.Core.Employees;

public interface IEmployeesRepository
{
    Task<Employee?> GetByIdAsync(Guid id);

    Task<List<Employee>> GetAllAsync();
    
    Task AddAsync(Employee employee);
    
    Task UpdateAsync(Employee employee);
    
    Task DeleteAsync(Employee employee);

    Task<bool> IsEmployeeEmailUniqueAsync(string email, Guid id);

    Task<bool> IsEmployeePhoneUniqueAsync(string phone, Guid id);
}
