using DotNetBoilerplate.Application.Devices;
using DotNetBoilerplate.Application.Devices.Get;
using DotNetBoilerplate.Application.Devices;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Devices
{
    public class GetAllDevicesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all devices");
        }

        private static async Task<Ok<List<DeviceDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetAllDevicesQuery();

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
