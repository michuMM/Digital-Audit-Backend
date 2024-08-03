using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Faults.Read
{
    public record GetAllFaultsByOrganizationIdQuery(Guid OrganizationId) : IQuery<List<FaultDto>>;
}