using DotNetBoilerplate.Shared.Abstractions.Commands;
using FluentValidation;

namespace DotNetBoilerplate.Application.DeviceCategories.Create;

public sealed record CreateDeviceCategoryCommand(Guid OrganizationId, string CategoryName) : ICommand<Guid>;

public class CreateDeviceCategoryCommandValidator : AbstractValidator<CreateDeviceCategoryCommand>
{
    public CreateDeviceCategoryCommandValidator()
    {
        RuleFor(command => command.CategoryName)
            .NotEmpty().WithMessage("Category name cannot be empty.")
            .Length(1, 50).WithMessage("Catregory name must be between 1 and 50 characters.");
    }
}
