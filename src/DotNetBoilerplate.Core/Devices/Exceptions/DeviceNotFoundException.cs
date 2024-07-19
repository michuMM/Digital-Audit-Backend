using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.Devices.Exceptions;

public sealed class DeviceNotFoundException : CustomException
{
    public Guid DeviceId { get; }

    public DeviceNotFoundException(Guid deviceId)
        : base($"Device with Id {deviceId} not found.")
    {
        DeviceId = deviceId;
    }
}