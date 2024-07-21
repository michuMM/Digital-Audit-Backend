using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Employees.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get;

public sealed class GetEmployeeByIdHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IEmployeesRepository _employeesRepository;
    
    public GetEmployeeByIdHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<EmployeeDto> HandleAsync(GetEmployeeByIdQuery query)
    {
        var employee = await _employeesRepository.GetByIdAsync(query.Id);
        if (employee is null)
        {
            throw new EmployeeIsNullException(query.Id);
        }

        return new EmployeeDto(
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.Phone
        );
    }
}
