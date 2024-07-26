namespace DotNetBoilerplate.Core.Faults;

public sealed class Fault
{
    private Fault()
    {
    }
    
    public Guid Id { get; private set; }

    public Guid DeviceId { get; private set; }

    public Guid ReporterId { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string DeviceStatus { get; private set; }

    public DateTimeOffset? DateIssuedForRepair { get; private set; }

    public DateTimeOffset? PlannedReturnDate { get; private set; }

    public DateTimeOffset? RepairDate { get; private set; }

    public static Fault Report(
        Guid deviceId,
        Guid reporterId,
        string name,
        string description,
        string deviceStatus,
        DateTimeOffset? dateIssuedForRepair,
        DateTimeOffset? plannedReturnDate,
        DateTimeOffset? repairDate
    )
    {        
        return new Fault
        {
            Id = Guid.NewGuid(), 
            DeviceId = deviceId,
            ReporterId = reporterId,
            Name = name,
            Description = description,
            DeviceStatus = deviceStatus,
            DateIssuedForRepair = dateIssuedForRepair,
            PlannedReturnDate = plannedReturnDate,
            RepairDate = repairDate
        };
    }
}

