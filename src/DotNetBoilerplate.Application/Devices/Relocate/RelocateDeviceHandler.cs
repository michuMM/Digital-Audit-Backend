using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Devices.Relocate;

internal sealed class RelocateDeviceHandler(
    IDevicesRepository devicesRepository,
    IContext context
) : ICommandHandler<RelocateDeviceCommand>
{
    public async Task HandleAsync(RelocateDeviceCommand command)
    {
        var device = await devicesRepository.GetByIdAsync(command.Id);
        if (device is null)
        {
            throw new DeviceNotFoundException(command.Id);
        }       

        device.Relocate(command.Localization);

        await devicesRepository.UpdateAsync(device);
    }
}
