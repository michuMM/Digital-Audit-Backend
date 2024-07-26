using DotNetBoilerplate.Application.DeviceAssignments;
using DotNetBoilerplate.Application.DeviceAssignments.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.DeviceAssignments
{
    public class GetAllDeviceAssignmentsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all device assignments");
        }

        private static async Task<Ok<List<DeviceAssignmentDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetAllDeviceAssignmentsQuery();

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
