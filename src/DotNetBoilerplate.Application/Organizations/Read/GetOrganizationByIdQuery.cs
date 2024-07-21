using DotNetBoilerplate.Application.Organizations.Read;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    public record GetOrganizationByIdQuery(Guid Id) : IQuery<OrganizationDto>;
}
