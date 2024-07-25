using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get
{
    public record GetAllDevicesByOrganizationIdQuery(Guid OrganizationId) : IQuery<List<DeviceDto>>;
}