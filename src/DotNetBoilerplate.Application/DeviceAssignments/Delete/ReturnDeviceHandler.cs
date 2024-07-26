using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceAssignments.Delete;

internal sealed class ReturnDeviceHandler(      
    IDeviceAssignmentsRepository deviceAssignmentsRepository
) : ICommandHandler<ReturnDeviceCommand, Guid>
{
    public async Task<Guid> HandleAsync(ReturnDeviceCommand command)
    {
        var deviceAssignment = await deviceAssignmentsRepository.GetByIdAsync(command.Id);
        if (deviceAssignment is null)
        {
            throw new Exception("device assignment not found");
        }        

        await deviceAssignmentsRepository.DeleteAsync(deviceAssignment);

        return deviceAssignment.Id;
    }
}