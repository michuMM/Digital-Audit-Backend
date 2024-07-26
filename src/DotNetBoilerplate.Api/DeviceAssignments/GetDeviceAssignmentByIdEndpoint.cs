using DotNetBoilerplate.Application.DeviceAssignments;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using DotNetBoilerplate.DeviceAssignments.Get;

namespace DotNetBoilerplate.Api.DeviceAssignments
{
    public class GetDeviceAssignmentByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get device assignment by id");
        }

        public static async Task<Ok<DeviceAssignmentDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetDeviceAssignmentByIdQuery(id);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
