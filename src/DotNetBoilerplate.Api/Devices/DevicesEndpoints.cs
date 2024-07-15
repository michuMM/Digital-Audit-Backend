namespace DotNetBoilerplate.Api.Devices;

internal static class DevicesEndpoints
{
    public const string BasePath = "devices";
    public const string Tags = "Devices";

    public static void MapDevicesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<AddDeviceEndpoint>();        
    }
}