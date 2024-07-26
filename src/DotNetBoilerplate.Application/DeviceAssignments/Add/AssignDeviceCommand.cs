using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Devices.Add;

public sealed record AssignDeviceCommand(        
    Guid DeviceId,
    Guid EmployeeId,    
    DateTimeOffset ReturnDate    
    ) : ICommand<Guid>;