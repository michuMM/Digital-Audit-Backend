using DotNetBoilerplate.Api.DeviceAssignments;

namespace DotNetBoilerplate.Api.DeviceAssignment;

internal static class DeviceAssignmentsEndpoints
{
    public const string BasePath = "/organizations/{organizationId}/deviceAssignments";
    public const string Tags = "DeviceAssignments";

    public static void MapDeviceAssignmentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<AssignDeviceEndpoint>()
            .MapEndpoint<GetAllDeviceAssignmentsEndpoint>()
            .MapEndpoint<GetDeviceAssignmentByIdEndpoint>()                        
            .MapEndpoint<ReturnDeviceByIdEndpoint>();
    }
}