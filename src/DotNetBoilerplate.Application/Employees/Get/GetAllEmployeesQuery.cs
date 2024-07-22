using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Employees.Get
{
    public sealed class GetAllEmployeesQuery : IQuery<List<EmployeeDto>>;
}