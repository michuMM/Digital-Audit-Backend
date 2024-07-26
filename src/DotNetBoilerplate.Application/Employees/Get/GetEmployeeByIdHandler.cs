using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get;

public sealed class GetEmployeeByIdHandler(IEmployeesRepository employeesRepository) : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IEmployeesRepository _employeesRepository = employeesRepository;

    public async Task<EmployeeDto?> HandleAsync(GetEmployeeByIdQuery query)
    {
        var employee = await _employeesRepository.GetByIdAsync(query.Id);
        if (employee is null)
        {
            return null;
        }

        return new EmployeeDto(
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.Phone
        );
    }
}
