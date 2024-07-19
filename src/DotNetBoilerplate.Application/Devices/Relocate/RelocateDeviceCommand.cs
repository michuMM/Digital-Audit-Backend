using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Devices.Relocate;

public sealed record RelocateDeviceCommand(Guid Id, string Localization) : ICommand<Guid>;