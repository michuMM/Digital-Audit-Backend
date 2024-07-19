using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get
{
    public sealed record GetDevicesByOrganizationIdQuery(Guid OrganizationId) : IQuery<IEnumerable<DeviceDto>>;
}
