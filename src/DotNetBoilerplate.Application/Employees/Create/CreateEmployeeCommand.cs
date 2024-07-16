using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Employees.Create;

public sealed record CreateEmployeeCommand(string First_Name, string Last_Name, string Email, string Phone) : ICommand<Guid>;