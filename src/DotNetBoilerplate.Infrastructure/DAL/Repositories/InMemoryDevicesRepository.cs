using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Organizations;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

public sealed class InMemoryDevicesRepository : IDevicesRepository
{
    private readonly List<Device> devices = [];


    public Task<Device> GetByIdAsync(Guid id)
    {
        var device = devices.Find(x => x.Id == id);

        return Task.FromResult(device);
    }

    public Task<List<Device>> GetAllAsync()
    {
        return Task.FromResult(devices);
    }

    public Task<List<Device>> GetAllByOrganizationIdAsync(Guid organizationId)
    {
        Console.WriteLine("Wykonuje GetAllByOrganizationId");
        var filtered = devices
            .Where(d => d.OrganizationId == organizationId)
            .ToList();

        Console.WriteLine($"Devices: {filtered}");
        return Task.FromResult(filtered);
    }

    public Task AddAsync(Device device)
    {
        devices.Add(device);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Device device)
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