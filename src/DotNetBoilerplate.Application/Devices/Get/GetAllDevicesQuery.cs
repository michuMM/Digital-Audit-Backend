using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get
{
    public sealed class GetAllDevicesQuery : IQuery<List<DeviceDto>>;
}