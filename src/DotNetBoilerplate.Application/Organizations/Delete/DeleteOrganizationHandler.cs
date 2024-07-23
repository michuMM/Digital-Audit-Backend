using DotNetBoilerplate.Application.Organizations.Delete;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Organizations.Delete
{
    internal sealed class DeleteOrganizationHandler(
        IOrganizationsRepository organizationRepository,
        IContext context
    ) : ICommandHandler<DeleteOrganizationCommand>
    {
        public async Task HandleAsync(DeleteOrganizationCommand command)
        {
            var organization = await organizationRepository.GetByIdAsync(command.OrganizationId);

            if (organization is null)
            {
                throw new Exception("Organization not found.");
            }

            await organizationRepository.DeleteAsync(organization);
        }
    }
}