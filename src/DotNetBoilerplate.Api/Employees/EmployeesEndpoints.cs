namespace DotNetBoilerplate.Api.Employees;

internal static class OrganizationsEndpoints
{
    public const string BasePath = "/organizations/{OrganizationId}/employees";
    public const string Tags = "Employees";

    public static void MapEmployeesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<CreateEmployeeEndpoint>();
    }
}
