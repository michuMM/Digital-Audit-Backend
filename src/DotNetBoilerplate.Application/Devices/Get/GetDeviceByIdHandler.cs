using DotNetBoilerplate.Application.Devices.Get;
using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get;

public sealed class GetDeviceByIdHandler : IQueryHandler<GetDeviceByIdQuery, DeviceDto>
{
    private readonly IDevicesRepository _devicesRepository;

    public GetDeviceByIdHandler(IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }

    public async Task<DeviceDto> HandleAsync(GetDeviceByIdQuery query)
    {
        var device = await _devicesRepository.GetByIdAsync(query.Id);
        if (device is null)
        {
            return null;
        }

        return new DeviceDto
        (
            device.Id,
            device.Name,
            device.OrganizationId,
            device.CategoryId,
            device.SerialNumber,
            device.DateOfPurchase,
            device.Localization,
            device.Status
        );
    }
}