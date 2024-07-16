using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;


namespace DotNetBoilerplate.Application.Employees.Create;

internal sealed class CreateEmployeeHandler(
    IEmployeesRepository employeesRepository
) : ICommandHandler<CreateEmployeeCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreateEmployeeCommand command)
    {
        var employee = Employee.NewEmployee(
           command.First_Name,
           command.Last_Name,
           command.Email,
           command.Phone
        );

        await employeesRepository.AddAsync(employee);

        return employee.Id;
    }
}
