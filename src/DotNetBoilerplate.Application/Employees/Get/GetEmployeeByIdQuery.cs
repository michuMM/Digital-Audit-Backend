using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get;

public record GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeDto>;