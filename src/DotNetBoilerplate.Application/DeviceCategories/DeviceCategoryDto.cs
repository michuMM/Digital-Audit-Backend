

namespace DotNetBoilerplate.Application.DeviceCategories
{
    public sealed record DeviceCategoryDto
    {
        public DeviceCategoryDto(Guid categoryId, Guid organizationId, string categoryName)
        {
            CategoryId = categoryId;
            OrganizationId = organizationId;
            CategoryName = categoryName;
        }

        public Guid CategoryId { get; private set; }

        public Guid OrganizationId { get;  private set; }

        public string CategoryName { get; set; }
    }
}
