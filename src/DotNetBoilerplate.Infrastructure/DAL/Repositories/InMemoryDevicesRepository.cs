using DotNetBoilerplate.Core.Devices;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

public sealed class InMemoryDevicesRepository : IDevicesRepository
{
    private readonly List<Device> devices = [];


    public Task<Device> GetByIdAsync(Guid id)
    {
        var device = devices.Find(x => x.Id == id);

        return Task.FromResult(device);
    }

    public Task AddAsync(Device device)
    {
        devices.Add(device);

        return Task.CompletedTask;
    }

    public Task RelocateAsync(Device device)
    {
        var existingDevice = devices.FirstOrDefault(x => x.Id == device.Id);

        if (existingDevice == null)
        {
            throw new InvalidOperationException("Device not found");
        }

        existingDevice.Localization = device.Localization;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Device device)
    {
        throw new NotImplementedException();
    }
}