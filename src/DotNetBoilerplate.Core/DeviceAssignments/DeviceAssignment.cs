namespace DotNetBoilerplate.Core.DeviceAssignments;

public class DeviceAssignment
{
    private DeviceAssignment()
    { 
    }

    public Guid Id { get; set; }
    public Guid DeviceId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid OrganizationId { get; set; }
    public DateTimeOffset IssueDate { get; set; }
    public DateTimeOffset ReturnDate { get; set; }
    public string ConditionOnReturn { get; set; }

    public static DeviceAssignment Assign(
        Guid deviceId,
        Guid employeeId,
        Guid organizationId,
        DateTimeOffset now,
        DateTimeOffset returnDate
    )
    {
        return new DeviceAssignment
        {
            Id = Guid.NewGuid(),
            DeviceId = deviceId,
            EmployeeId = employeeId,
            OrganizationId = organizationId,
            IssueDate = now,
            ReturnDate = returnDate
        };
    }

    public void Modify(
        Guid employeeId,
        Guid deviceId
    )
    {
        EmployeeId = employeeId;
        DeviceId = deviceId;
    }        
}

//TO DO
// CORRECTIONS:
// - info o osobie ktora wykonała wydanie urządzenia?
//   - i tak robi to tylko admin więc czy jest sens?
// 
//
//
// EXCEPTIONS:
// - dodac exception EmployeeNotFound
// - dodac exception "CzyToUrzadzenieJestGdziesJuzPrzypisane"
//      -nie powinno byc przypisane do wiecej niz jednego pracownika