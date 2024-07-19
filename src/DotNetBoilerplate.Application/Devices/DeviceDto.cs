namespace DotNetBoilerplate.Application.Devices
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CategoryId { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset DateOfPurchase { get; set; }
        public string Localization { get; set; }
        public string Status { get; set; }
    }
}
