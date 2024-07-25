using DotNetBoilerplate.Application.DeviceCategories.Delete;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static DotNetBoilerplate.Core.DeviceCategories.DeviceCategory;

namespace DotNetBoilerplate.Api.DeviceCategories;

internal sealed class DeleteDeviceCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Delete device category by ID");
    }

    private static async Task<Ok<Response>> Handle(
        Guid id,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new DeleteDeviceCategoryCommand(id);

        await commandDispatcher.DispatchAsync<DeleteDeviceCategoryCommand>(command, ct);

        return TypedResults.Ok(new Response());
    }

    internal sealed record Response();
}
