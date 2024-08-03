namespace DotNetBoilerplate.Core.DeviceAssignments;
public interface IDeviceAssignmentsRepository
{
    Task<DeviceAssignment?> GetByIdAsync(Guid id);

    Task<List<DeviceAssignment>> GetAllAsync();

    Task<List<DeviceAssignment>> GetAllByOrganizationIdAsync(Guid id);

    Task AddAsync(DeviceAssignment deviceAssignment);

    Task UpdateAsync(DeviceAssignment deviceAssignment);

    Task DeleteAsync(DeviceAssignment deviceAssignment);
}