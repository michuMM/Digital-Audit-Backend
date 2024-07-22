using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;
using DotNetBoilerplate.Shared.Abstractions.Time;
using FluentValidation;
using DotNetBoilerplate.Core.Organizations.Exceptions;
using System;
using System.Threading.Tasks;

namespace DotNetBoilerplate.Application.Organizations.Create;

internal sealed class CreateOrganizationHandler(
    IOrganizationsRepository organizationsRepository,
    IContext context,
    IClock clock,
    IValidator<CreateOrganizationCommand> validator
) : ICommandHandler<CreateOrganizationCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreateOrganizationCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new OrganizationNameIsEmpty();
        }

        var isNameUnique =
            await organizationsRepository.IsOrganizationNameUniqueAsync(command.Name, Guid.Empty);

        var organization = Organization.Create(
            command.Name,
            context.Identity.Id,
            clock.Now(),
            isNameUnique
        );

        await organizationsRepository.AddAsync(organization);
        
        return organization.Id;
    }
}