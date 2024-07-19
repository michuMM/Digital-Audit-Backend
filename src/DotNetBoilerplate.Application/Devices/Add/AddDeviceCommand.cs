using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Devices.Add;

public sealed record AddDeviceCommand(
    string Name, 
    Guid OrganizationId, 
    Guid CategoryId, 
    String SerialNumber,
    DateTimeOffset DateOfPurchase,
    String Localization,
    String Status
    ) : ICommand<Guid>;