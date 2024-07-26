using DotNetBoilerplate.Shared.Abstractions.Commands; 

namespace DotNetBoilerplate.Application.Employees.Update;

public sealed record UpdateEmployeeCommand(Guid id, string firstName, string lastName, string email, string phone) : ICommand<Guid>;
