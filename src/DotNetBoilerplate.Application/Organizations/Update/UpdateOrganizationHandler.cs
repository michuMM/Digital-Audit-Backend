using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Organizations.Update;

internal sealed class UpdateOrganizationHandler(
    IOrganizationsRepository organizationsRepository,
    IContext context
) : ICommandHandler<UpdateOrganizationCommand>
{
    public async Task HandleAsync(UpdateOrganizationCommand command)
    {
        var organization = await organizationsRepository.GetByIdAsync(command.Id);
        if (organization == null)
        {
            throw new OrganizationNotFoundException();
        }

        var isNameUnique = await organizationsRepository.IsOrganizationNameUniqueAsync(command.Name);

        organization.Update(command.Name, isNameUnique);

        await organizationsRepository.UpdateAsync(organization);
    }
}
