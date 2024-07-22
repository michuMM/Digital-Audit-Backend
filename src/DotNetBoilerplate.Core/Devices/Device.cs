using DotNetBoilerplate.Core.Organizations.Exceptions;

namespace DotNetBoilerplate.Core.Devices;

public sealed class Device
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

    public String Localization {  get; set; }

    public String Status {  get; private set; }

    public static Device Add(
        string name,
        Guid organizationId,
        Guid categoryId,
        string serialNumber,
        DateTimeOffset dateOfPurchase,
        String localization,
        String status
    )
    {     
        return new Device
        {
            Id = Guid.NewGuid(),
            Name = name,
            OrganizationId = organizationId,
            CategoryId= categoryId,
            SerialNumber = serialNumber,
            DateOfPurchase = dateOfPurchase,
            Localization = localization,
            Status = status
        };
    }

    public void Relocate(string localization)
    {        
        Localization = localization;
    }
}