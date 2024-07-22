using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Employees.Exceptions;

internal sealed class EmployeePhoneNumberIsNotUniqueException() : CustomException("Employee phone number is not unique");