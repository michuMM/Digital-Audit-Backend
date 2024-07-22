using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Employees.Exceptions;

internal sealed class EmployeeNotFoundException() : CustomException("Employee is not found.");
