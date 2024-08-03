using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Core.DeviceAssignments.Exceptions;
using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Employees.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.DeviceAssignments.Update;

internal sealed class ModifyDeviceAssignmentHandler(
    IDeviceAssignmentsRepository deviceAssignmentsRepository,
    IDevicesRepository devicesRepository,
    IEmployeesRepository employeesRepository
) : ICommandHandler<ModifyDeviceAssignmentCommand>
{
    public async Task HandleAsync(ModifyDeviceAssignmentCommand command)
    {
        var deviceAssignment = await deviceAssignmentsRepository.GetByIdAsync(command.Id);
        if (deviceAssignment is null)
        {
            throw new DeviceAssignmentNotFoundException(command.Id);
        }

        var device = await devicesRepository.GetByIdAsync(command.Id);
        if (device is null)
        {
            throw new DeviceNotFoundException(command.Id);
        }

        var employee = await employeesRepository.GetByIdAsync(command.Id);
        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        deviceAssignment.Modify(command.EmployeeId, command.DeviceId);

        await deviceAssignmentsRepository.UpdateAsync(deviceAssignment);
    }
}
