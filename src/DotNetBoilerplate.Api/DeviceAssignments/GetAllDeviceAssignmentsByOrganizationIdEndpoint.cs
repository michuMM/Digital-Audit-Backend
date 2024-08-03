using DotNetBoilerplate.Application.DeviceAssignments;
using DotNetBoilerplate.Application.DeviceAssignments.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.DeviceAssignments
{
    public class GetAllDeviceAssignmentsByOrganizationIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("fromOrganization", Handle)
                .RequireAuthorization()
                .WithSummary("Get all device assignments by organization id");
        }

        private static async Task<Ok<List<DeviceAssignmentDto>>> Handle(
            [FromRoute] Guid organizationId,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetAllDeviceAssignmentsByOrganizationIdQuery(organizationId);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
