using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceAssignments.Delete;

public sealed record ReturnDeviceCommand(Guid Id) : ICommand<Guid>;