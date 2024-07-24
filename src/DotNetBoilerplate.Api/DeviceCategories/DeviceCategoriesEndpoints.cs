namespace DotNetBoilerplate.Api.DeviceCategories;

internal static class DeviceCategoriesEndpoints
{
    public const string BasePath = "deviceCategories";
    public const string Tags = "DeviceCategories";

    public static void MapDeviceCategoriesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<CreateDeviceCategoryEndpoint>()
            .MapEndpoint<GetAllDeviceCategoriesEndpoint>();
    }
}
