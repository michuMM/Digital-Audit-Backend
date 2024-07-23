using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Devices.Delete;

internal sealed class DeleteDeviceHandler(
    IDevicesRepository devicesRepository,
    IContext context
) : ICommandHandler<DeleteDeviceCommand>
{
    public async Task HandleAsync(DeleteDeviceCommand command)
    {
        var device = await devicesRepository.GetByIdAsync(command.deviceId);
        if (device is null)
        {
            throw new DeviceNotFoundException(command.deviceId);
        }

        await devicesRepository.DeleteAsync(device);
    }
}
