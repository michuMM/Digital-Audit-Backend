namespace DotNetBoilerplate.Application.Faults
{
    public record FaultDto
    {
        public FaultDto(
            Guid id,
            Guid deviceId,
            Guid reporterId,
            Guid organizationId,
            string name,
            string description,
            string deviceStatus,
            DateTimeOffset? dateIssuedForRepair,
            DateTimeOffset? plannedReturnDate,
            DateTimeOffset? repairDate

        )
        {
            Id = id;
            DeviceId = deviceId;
            ReporterId = reporterId;
            OrganizationId = organizationId;
            Name = name;
            Description = description;
            DeviceStatus = deviceStatus;
            DateIssuedForRepair = dateIssuedForRepair;
            PlannedReturnDate = plannedReturnDate;
            RepairDate = repairDate;

            
        }

        public Guid Id { get; private set; }

        public Guid DeviceId { get; private set; }

        public Guid ReporterId { get; private set; }

        public Guid OrganizationId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string DeviceStatus { get; private set; }

        public DateTimeOffset? DateIssuedForRepair { get; private set; }

        public DateTimeOffset? PlannedReturnDate { get; private set; }

        public DateTimeOffset? RepairDate { get; private set; }

    }
}