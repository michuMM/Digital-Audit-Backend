using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Organizations.Read;

public sealed class GetOrganizationByIdHandler : IQueryHandler<GetOrganizationByIdQuery, OrganizationDto>
{
    private readonly IOrganizationsRepository _organizationsRepository;

    public GetOrganizationByIdHandler(IOrganizationsRepository organizationsRepository)
    {
        _organizationsRepository = organizationsRepository;
    }

    public async Task<OrganizationDto> HandleAsync(GetOrganizationByIdQuery query)
    {
        var organization = await _organizationsRepository.GetByIdAsync(query.Id);
        if (organization is null)
        {
            return null;
        }

        return new OrganizationDto
        (
            organization.Id,
            organization.Name,
            organization.OwnerId,
            organization.CreatedAt
        );
    }
}