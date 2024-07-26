using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Employees.Exceptions;

public sealed class EmployeeNotFoundException() : CustomException("Employee is not found.");
