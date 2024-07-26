using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Faults.Report;

public sealed record ReportFaultCommand(
    Guid DeviceId,
    Guid ReporterId,
    string Name,
    string Description,
    string DeviceStatus,
    DateTimeOffset? DateIssuedForRepair = null,
    DateTimeOffset? PlannedReturnDate = null ,
    DateTimeOffset? RepairDate = null
    ) : ICommand<Guid>;