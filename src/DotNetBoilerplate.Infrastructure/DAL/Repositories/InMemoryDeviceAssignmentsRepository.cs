using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Core.Devices;

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
        return Task.FromResult(deviceAssignments);
    }

    public Task<List<DeviceAssignment>> GetAllByOrganizationIdAsync(Guid organizationId)
    {    
        var filtered = deviceAssignments
            .Where(da => da.OrganizationId == organizationId)
            .ToList();
        
        return Task.FromResult(filtered);
    }

    public Task AddAsync(DeviceAssignment deviceAssignment)
    {        
        deviceAssignments.Add(deviceAssignment);  
        return Task.CompletedTask;
    }

    public Task UpdateAsync(DeviceAssignment deviceAssignment)
    {
        var existingDeviceAssignment = deviceAssignments.FirstOrDefault(x => x.Id == deviceAssignment.Id);

        if (existingDeviceAssignment == null)
        {
            throw new InvalidOperationException("Device Assignment not found");
        }

        existingDeviceAssignment.EmployeeId = deviceAssignment.EmployeeId;
        existingDeviceAssignment.DeviceId = deviceAssignment.DeviceId;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(DeviceAssignment deviceAssignment)
    {
        deviceAssignments.Remove(deviceAssignment);
        return Task.CompletedTask;
    }
}