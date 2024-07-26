using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Core.Employees.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Time;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Employees;

namespace DotNetBoilerplate.Application.DeviceAssignments.Add;

internal sealed class AssignDeviceHandler(
    IDeviceAssignmentsRepository deviceAssignmentsRepository,
    IDevicesRepository devicesRepository,
    IEmployeesRepository employeesRepository,
    IClock clock
) : ICommandHandler<AssignDeviceCommand, Guid>
{
    public async Task<Guid> HandleAsync(AssignDeviceCommand command)
    {
        var device = await devicesRepository.GetByIdAsync(command.DeviceId);
        if (device is null)
        {
            throw new DeviceNotFoundException(command.DeviceId);
        }

        var employee = await employeesRepository.GetByIdAsync(command.EmployeeId);
        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        var deviceAssignment = DeviceAssignment.Assign(
            command.DeviceId,
            command.EmployeeId,
            clock.Now(),
            command.ReturnDate
        );

        await deviceAssignmentsRepository.AddAsync(deviceAssignment);

        return device.Id;
    }
}