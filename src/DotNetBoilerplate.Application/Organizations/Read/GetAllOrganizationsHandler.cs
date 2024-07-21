using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Read
{
    internal sealed class GetAllOrganizationsHandler(
        IOrganizationsRepository organizationsRepository
        ) : IQueryHandler<GetAllOrganizationsQuery, List<OrganizationDto>>
    {
        public async Task<List<OrganizationDto>> HandleAsync(GetAllOrganizationsQuery query)
        {
            var organizations = await organizationsRepository.GetAllAsync();
            return organizations.Select(o => new OrganizationDto(o.Id, o.Name, o.OwnerId, o.CreatedAt.UtcDateTime)).ToList();
        }
    }    
}





