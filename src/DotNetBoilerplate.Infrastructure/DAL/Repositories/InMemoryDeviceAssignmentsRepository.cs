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
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DeviceAssignment deviceAssignment)
    {
        deviceAssignments.Remove(deviceAssignment);
        return Task.CompletedTask;
    }
}