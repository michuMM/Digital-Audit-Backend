using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Devices.Delete;

public sealed record DeleteDeviceCommand(Guid deviceId) : ICommand<Guid>;
