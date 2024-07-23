using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Organizations.Delete;

public sealed record DeleteOrganizationCommand(Guid OrganizationId) : ICommand<Guid>;
