using DotNetBoilerplate.Core.DeviceAssignments;

namespace DotNetBoilerplate.Infrastructure.DAL.Repositories;

public sealed class InMemoryDeviceAssignmentsRepository : IDeviceAssignmentsRepository
{
    private readonly List<DeviceAssignment> deviceAssignments = [];

    public Task<DeviceAssignment> GetByIdAsync(Guid id)
    {
        var deviceAssignment = deviceAssignments.Find(x => x.Id == id);

        return Task.FromResult(deviceAssignment);
    }

    public Task<List<DeviceAssignment>> GetAllAsync()
    {
        Console.WriteLine($"Liczba urządzeń: {deviceAssignments.Count}");
        return Task.FromResult(deviceAssignments);
    }    

    public Task AddAsync(DeviceAssignment deviceAssignment)
    {
        Console.WriteLine($"Dodawanie urządzenia: {deviceAssignment.Id}");
        deviceAssignments.Add(deviceAssignment);  
        return Task.CompletedTask;
    }

    public Task UpdateAsync(DeviceAssignment deviceAssignment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DeviceAssignment deviceAssignment)
    {
        throw new NotImplementedException();
    }
}