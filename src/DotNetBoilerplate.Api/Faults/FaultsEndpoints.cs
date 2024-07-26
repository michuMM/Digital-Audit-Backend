namespace DotNetBoilerplate.Api.Faults;

internal static class FaultsEndpoints
{
    public const string BasePath = "/organizations/{OrganizationId}/faults";
    public const string Tags = "Faults";

    public static void MapFaultsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<ReportFaultEndpoint>();
    }
}
