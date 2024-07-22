using DotNetBoilerplate.Shared.Abstractions.Commands;
using FluentValidation;

namespace DotNetBoilerplate.Application.Employees.Create;

public sealed record CreateEmployeeCommand(Guid OrganizationId, string FirstName, string LastName, string Email, string Phone) : ICommand<Guid>;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(command => command.Phone)
            .NotEmpty().WithMessage("Phone number cannot be empty.")
            .Matches(@"^\d{9}$").WithMessage("Phone number must be 9 digits.");

        RuleFor(command => command.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty.")
            .Length(2, 60).WithMessage("First name must be between 2 and 60 characters.");

        RuleFor(command => command.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty.")
            .Length(2, 60).WithMessage("Last name must be between 2 and 60 characters.");
    }
}