using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Employees.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Update;

internal sealed class UpdateEmployeeHandler (
    IEmployeesRepository employeesRepository,
    IContext context
) : ICommandHandler<UpdateEmployeeCommand>
{
    public async Task HandleAsync(UpdateEmployeeCommand command)
    {
        var employee = await employeesRepository.GetByIdAsync(command.id);
        if (employee == null)
        {
            throw new EmployeeNotFoundException();
        }

        var isEmailUnique = await employeesRepository.IsEmployeeEmailUniqueAsync(command.email, command.id);
        var isPhoneUnique = await employeesRepository.IsEmployeePhoneUniqueAsync(command.phone, command.id);

        employee.Update(
            command.firstName,
            command.lastName,
            command.email,
            command.phone,
            isEmailUnique,
            isPhoneUnique
        );

        await employeesRepository.UpdateAsync(employee);
    }
}
