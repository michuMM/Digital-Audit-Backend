namespace DotNetBoilerplate.Core.Devices;
public interface IDevicesRepository
{
    Task<Device?> GetByIdAsync(Guid id);

    Task<IEnumerable<Device>> GetDevicesByOrganizationIdAsync(Guid organizationId);

    Task AddAsync(Device device);

    Task RelocateAsync(Device device);

    Task DeleteAsync(Device device);
}