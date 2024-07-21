using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    public sealed class GetAllOrganizationsQuery : IQuery<List<OrganizationDto>>;
}
