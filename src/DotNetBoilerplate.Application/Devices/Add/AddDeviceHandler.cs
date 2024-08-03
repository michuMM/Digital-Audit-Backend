using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Organizations;
using DotNetBoilerplate.Core.Organizations.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Devices.Add;

internal sealed class AddDeviceHandler(
    IDevicesRepository devicesRepository,
    IOrganizationsRepository organizationsRepository
) : ICommandHandler<AddDeviceCommand, Guid>
{
    public async Task<Guid> HandleAsync(AddDeviceCommand command)
    {
        var organization = await organizationsRepository.GetByIdAsync(command.OrganizationId);
        if (organization is null)
        {
            throw new OrganizationNotFoundException();
        }

        var device = Device.Add(
            command.Name,
            command.OrganizationId,
            command.CategoryId,
            command.SerialNumber,
            command.DateOfPurchase,
            command.Localization,
            command.Status
        );

        await devicesRepository.AddAsync(device);

        return device.Id;
    }
}
