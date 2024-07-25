using DotNetBoilerplate.Core.DeviceCategories.Exceptions;

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

    public void UpdateCategory(string categoryName, bool isDeviceCategoryUnique)
    {
        if (!isDeviceCategoryUnique)
        {
            throw new DeviceCategoryNameIsNotUnique();
        }

        CategoryName = categoryName;
    }
}
