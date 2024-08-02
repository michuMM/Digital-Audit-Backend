using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceAssignments.Get
{
    public record GetAllDeviceAssignmentsByOrganizationIdQuery(Guid OrganizationId) : IQuery<List<DeviceAssignmentDto>>;
}