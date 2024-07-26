namespace DotNetBoilerplate.Api.Devices;

internal static class DevicesEndpoints
{
    public const string BasePath = "/organizations/{organizationId}/devices";
    public const string Tags = "Devices";

    public static void MapDevicesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<AddDeviceEndpoint>()
            .MapEndpoint<RelocateDeviceEndpoint>()
            .MapEndpoint<GetAllDevicesEndpoint>()
            .MapEndpoint<GetDeviceByIdEndpoint>();
                         
    }
}