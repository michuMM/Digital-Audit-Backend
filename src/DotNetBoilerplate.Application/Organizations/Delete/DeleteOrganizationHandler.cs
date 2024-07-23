using DotNetBoilerplate.Application.Organizations.Delete;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Organizations.Delete
{
    internal sealed class DeleteProjectHandler(
        IOrganizationsRepository projectRepository,
        IContext context
    ) : ICommandHandler<DeleteOrganizationCommand>
    {
        public async Task HandleAsync(DeleteOrganizationCommand command)
        {
            var project = await projectRepository.GetByIdAsync(command.OrganizationId);

            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            await projectRepository.DeleteAsync(project);
        }
    }
}