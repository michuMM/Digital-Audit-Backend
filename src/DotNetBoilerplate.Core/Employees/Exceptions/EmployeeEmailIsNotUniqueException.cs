using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Employees.Exceptions;

internal sealed class EmployeeEmailIsNotUniqueException() : CustomException("Employee email is not unique");
