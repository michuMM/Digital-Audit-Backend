using DotNetBoilerplate.Application.Devices;
using DotNetBoilerplate.Application.Devices.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Devices
{
    internal sealed class GetDevicesByOrganizationIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{organizationId:guid}/devices", Handle)
                .RequireAuthorization()
                .WithSummary("Get devices by organization Id");
        }

        private static async Task<Ok<IEnumerable<DeviceDto>>> Handle(
            [FromRoute] Guid organizationId,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken cancellationToken
        )
        {
            var query = new GetDevicesByOrganizationIdQuery(organizationId);
            var devices = await queryDispatcher.QueryAsync<IEnumerable<DeviceDto>>(query, cancellationToken);
            return TypedResults.Ok(devices);
        }
    }
}
