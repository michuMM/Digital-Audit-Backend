using DotNetBoilerplate.Application.Employees.Read;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Read
{
    public record GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeDto>;
}
