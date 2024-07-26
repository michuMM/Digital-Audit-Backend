namespace DotNetBoilerplate.Application.Devices
{
    public record DeviceDto
    {
        public DeviceDto(
            Guid id,
            string name,              
            Guid organizationId, 
            Guid categoryId, 
            String serialNumber, 
            DateTimeOffset dateOfPurchase,
            String localization, 
            String status
        )
        {
            Id = id;
            Name = name;
            OrganizationId = organizationId;
            CategoryId = categoryId;
            SerialNumber = serialNumber;
            DateOfPurchase = dateOfPurchase;
            Localization = localization;
            Status = status;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Guid OrganizationId { get; private set; }

        public Guid CategoryId { get; private set; }

        public String SerialNumber { get; private set; }

        public DateTimeOffset DateOfPurchase { get; private set; }

        public String Localization { get; set; }

        public String Status { get; private set; }

    }
}