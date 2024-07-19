using DotNetBoilerplate.Shared.Abstractions.Queries;
using DotNetBoilerplate.Core.Devices;

namespace DotNetBoilerplate.Application.Devices.Get
{
    internal sealed class GetDevicesByOrganizationIdHandler(
        IDevicesRepository devicesRepository
    ) : IQueryHandler<GetDevicesByOrganizationIdQuery, IEnumerable<DeviceDto>>
    {
        public async Task<IEnumerable<DeviceDto>> HandleAsync(GetDevicesByOrganizationIdQuery query)
        {
            var devices = await devicesRepository.GetDevicesByOrganizationIdAsync(query.OrganizationId);
            var deviceDtos = devices.Select(device => new DeviceDto
            {
                Id = device.Id,
                Name = device.Name,
                OrganizationId = device.OrganizationId,
                CategoryId = device.CategoryId,
                SerialNumber = device.SerialNumber,
                DateOfPurchase = device.DateOfPurchase,
                Localization = device.Localization,
                Status = device.Status
            });

            return deviceDtos;
        }
    }
}
