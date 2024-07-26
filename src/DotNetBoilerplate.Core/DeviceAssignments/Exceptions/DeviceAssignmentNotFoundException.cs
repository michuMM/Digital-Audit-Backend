using DotNetBoilerplate.Shared.Abstractions.Exceptions;

namespace DotNetBoilerplate.Core.DeviceAssignments.Exceptions;

public sealed class DeviceAssignmentNotFoundException : CustomException
{
    public Guid DeviceAssignmentId { get; }

    public DeviceAssignmentNotFoundException(Guid deviceAssignmentId)
        : base($"Device assignment with Id {deviceAssignmentId} not found.")
    {
        DeviceAssignmentId = deviceAssignmentId;
    }
}