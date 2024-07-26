using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Devices.Get
{
    internal sealed class GetAllDevicesByOrganizationIdHandler(
        IDevicesRepository devicesRepository
    ) : IQueryHandler<GetAllDevicesByOrganizationIdQuery, List<DeviceDto>>
    {
        public async Task<List<DeviceDto>> HandleAsync(GetAllDevicesByOrganizationIdQuery query)
        {
            Console.WriteLine("Wykonuje Handlera");
            var devices = await devicesRepository.GetAllByOrganizationIdAsync(query.OrganizationId);
            return devices.Select(d => new DeviceDto(d.Id, d.Name, d.OrganizationId, d.CategoryId, d.SerialNumber, d.DateOfPurchase, d.Localization, d.Status)).ToList();
        }
    }
}