using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Employees.Exceptions
{
    public sealed class EmployeeIsNullException(Guid Id) : CustomException($"Employeee {Id} does not exist") { }
}
