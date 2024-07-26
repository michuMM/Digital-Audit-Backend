using DotNetBoilerplate.Application.Devices.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get
{
    public record GetDeviceByIdQuery(Guid Id) : IQuery<DeviceDto>;
}
