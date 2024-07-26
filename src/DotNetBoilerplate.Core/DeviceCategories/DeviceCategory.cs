

namespace DotNetBoilerplate.Core.DeviceCategories;

public class DeviceCategory
{
    private DeviceCategory() 
    { 
    }

    public Guid CategoryId { get; private set; }

    public Guid OrganizationId { get; private set; }

    public string CategoryName { get;  set; }

    public static DeviceCategory CreateCategory(
        Guid organizationId, 
        string categoryName
    )
    {
        return new DeviceCategory()
        {
            CategoryId = Guid.NewGuid(),
            OrganizationId = organizationId,
            CategoryName = categoryName
        };
    }
}
