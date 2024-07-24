using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceAssignments.Add;

public sealed record AssignDeviceCommand(        
    Guid DeviceId,
    Guid EmployeeId,    
    DateTimeOffset ReturnDate    
    ) : ICommand<Guid>;