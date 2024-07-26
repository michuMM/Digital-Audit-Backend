using DotNetBoilerplate.Application.Devices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using DotNetBoilerplate.Application.Devices.Get;

namespace DotNetBoilerplate.Api.Devices
{
    public class GetDeviceByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get device by id");
        }

        public static async Task<Ok<DeviceDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetDeviceByIdQuery(id);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
