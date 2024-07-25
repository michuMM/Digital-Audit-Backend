using DotNetBoilerplate.Application.Devices;
using DotNetBoilerplate.Application.Devices.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Devices
{
    public class GetAllDevicesByOrganizationIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("fromOrganization", Handle)
                .RequireAuthorization()
                .WithSummary("Get all devices by organization id");
        }

        private static async Task<Ok<List<DeviceDto>>> Handle(
            [FromRoute] Guid organizationId,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetAllDevicesByOrganizationIdQuery(organizationId);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
