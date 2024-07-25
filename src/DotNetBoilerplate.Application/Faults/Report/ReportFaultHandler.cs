using DotNetBoilerplate.Core.Faults;
using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Core.Employees;
using DotNetBoilerplate.Core.Employees.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using DotNetBoilerplate.Shared.Abstractions.Contexts;

namespace DotNetBoilerplate.Application.Faults.Report;

internal sealed class ReportFaultHandler(
    IFaultsRepository faultsRepository,
    IDevicesRepository devicesRepository,
    IEmployeesRepository employeesRepository,
    IContext context
) : ICommandHandler<ReportFaultCommand, Guid>
{
    public async Task<Guid> HandleAsync(ReportFaultCommand command)
    {
        var device = await devicesRepository.GetByIdAsync(command.DeviceId);
        if (device is null)
        {
            throw new DeviceNotFoundException(command.DeviceId);
        }

        var employee = await employeesRepository.GetByIdAsync(command.ReporterId);
        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        var fault = Fault.Report(
            command.DeviceId,
            command.ReporterId,
            command.Name,
            command.Description,
            command.DeviceStatus,
            command.DateIssuedForRepair,
            command.PlannedReturnDate,
            command.RepairDate
        );

        await faultsRepository.AddAsync(fault);

        return fault.Id;
    }
}