﻿namespace DotNetBoilerplate.Api.Organizations;

internal static class OrganizationsEndpoints
{
    public const string BasePath = "orgnizations";
    public const string Tags = "Organizations";

    public static void MapOrganizationsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags(Tags);

        group
            .MapEndpoint<CreateOrganizationEndpoint>()
            .MapEndpoint<UpdateOrganizationEndpoint>()
            .MapEndpoint<GetOrganizationByIdEndpoint>()
            .MapEndpoint<GetAllOrganizationsEndpoint>()
            .MapEndpoint<DeleteOrganizationEndpoint>();
    }
}
