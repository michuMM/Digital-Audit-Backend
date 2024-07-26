using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get
{
    internal sealed class GetAllDevicesHandler(
        IDevicesRepository devicesRepository
    ) : IQueryHandler<GetAllDevicesQuery, List<DeviceDto>>
    {
        public async Task<List<DeviceDto>> HandleAsync(GetAllDevicesQuery query)
        {
            var devices = await devicesRepository.GetAllAsync();
            return devices.Select(d => new DeviceDto(d.Id, d.Name, d.OrganizationId, d.CategoryId, d.SerialNumber, d.DateOfPurchase, d.Localization, d.Status)).ToList();
        }
    }

}