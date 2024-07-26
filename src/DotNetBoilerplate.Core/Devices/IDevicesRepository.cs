using DotNetBoilerplate.Core.Organizations;

namespace DotNetBoilerplate.Core.Devices;
public interface IDevicesRepository
{
    Task<Device?> GetByIdAsync(Guid id);

    Task<List<Device>> GetAllAsync();

    Task<List<Device>> GetAllByOrganizationIdAsync(Guid organizationId);
    Task AddAsync(Device device);

    Task UpdateAsync(Device device);

    Task DeleteAsync(Device device);
}