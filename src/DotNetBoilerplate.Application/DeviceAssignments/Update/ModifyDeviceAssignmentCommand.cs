using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceAssignments.Update;

public sealed record ModifyDeviceAssignmentCommand(Guid Id, Guid EmployeeId, Guid DeviceId) : ICommand<Guid>;
