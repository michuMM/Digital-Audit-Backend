using DotNetBoilerplate.Application.DeviceAssignments;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.DeviceAssignments.Get
{
    public record GetDeviceAssignmentByIdQuery(Guid Id) : IQuery<DeviceAssignmentDto>;
}
