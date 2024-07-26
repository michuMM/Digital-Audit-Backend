using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.DeviceAssignments.Get
{
    public sealed class GetAllDeviceAssignmentsQuery : IQuery<List<DeviceAssignmentDto>>;
}