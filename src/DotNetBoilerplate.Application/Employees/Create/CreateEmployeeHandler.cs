using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using FluentValidation;


namespace DotNetBoilerplate.Application.Employees.Create;

internal sealed class CreateEmployeeHandler(IEmployeesRepository employeesRepository, IValidator<CreateEmployeeCommand> validator) : ICommandHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeesRepository _employeesRepository = employeesRepository;
    private readonly IValidator<CreateEmployeeCommand> _validator = validator;

    public async Task<Guid> HandleAsync(CreateEmployeeCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid) 
        {
            throw new ValidationException(validationResult.Errors);        
        }

        var employee = Employee.NewEmployee(
           command.OrganizationId,
           command.FirstName,
           command.LastName,
           command.Email,
           command.Phone
        );

        await _employeesRepository.AddAsync(employee);

        return employee.Id;
    }
}
