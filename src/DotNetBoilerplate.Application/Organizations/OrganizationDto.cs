namespace DotNetBoilerplate.Application.Organizations
{
    public class OrganizationDto
    {
        public OrganizationDto(Guid id, string name, Guid ownerId, DateTimeOffset createdAt)
        {
            Id = id;
            Name = name;
            OwnerId = ownerId;
            CreatedAt = createdAt;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}