using FluentValidation;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Core.Organizations.Exceptions;

namespace DotNetBoilerplate.Application.Organizations.Create;

public sealed record CreateOrganizationCommand(string Name) : ICommand<Guid>;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Organization name cannot be empty.");
    }
}