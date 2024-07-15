namespace DotNetBoilerplate.Core.Devices;

public class Device
{
    private Device()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Guid OrganizationId { get; private set; }

    public Guid CategoryId { get; private set; }

    public String SerialNumber { get; private set; }

    public DateTimeOffset DateOfPurchase { get; private set; }

    public String Localization {  get; private set; }

    public String Status {  get; private set; }

    public static Device Add(
        string name,
        Guid OrganizationId,
        Guid CategoryId,
        string SerialNumber,
        DateTimeOffset DateOfPurchase,
        String Localization,
        String Status
    )
    {     
        return new Device
        {
            Id = Guid.NewGuid(),
            Name = name,
            OrganizationId = OrganizationId,
            CategoryId= CategoryId,
            SerialNumber = SerialNumber,
            DateOfPurchase = DateOfPurchase,
            Localization = Localization,
            Status = Status
        };
    }
}