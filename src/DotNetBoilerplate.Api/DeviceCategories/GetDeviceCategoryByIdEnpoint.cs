using DotNetBoilerplate.Application.DeviceCategories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using DotNetBoilerplate.Application.DeviceCategories.Get;


namespace DotNetBoilerplate.Api.DeviceCategories
{
    public class GetDeviceCategoryByIdEnpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get device category by id");
        }

        public static async Task<Ok<DeviceCategoryDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetDeviceCategoryByIdQuery(id);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
