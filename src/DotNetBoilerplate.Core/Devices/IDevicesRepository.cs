namespace DotNetBoilerplate.Core.Devices;
public interface IDevicesRepository
{
    Task<Device?> GetByIdAsync(Guid id);

    Task AddAsync(Device device);

    Task UpdateAsync(Device device);

    Task DeleteAsync(Device device);
}