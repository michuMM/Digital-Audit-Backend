using DotNetBoilerplate.Application.Employees.Delete;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Employees.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Employees.Delete;

internal sealed class DeleteEmployeeHandler(
    IEmployeesRepository employeesRepository,
    IContext context
) : ICommandHandler<DeleteEmployeeCommand>
{
    public async Task HandleAsync(DeleteEmployeeCommand command)
    {
        var employee = await employeesRepository.GetByIdAsync(command.id);

        if (employee == null)
        {
            throw new EmployeeNotFoundException();
        }

        await employeesRepository.DeleteAsync(employee);
    }
}
