using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.DeviceCategories.Update;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.DeviceCategories;

internal sealed class UpdateDeviceCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Update device category");
    }

    private static async Task<Results<Ok<Response>, NotFound>> Handle(
        Guid categoryId,
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new UpdateDeviceCategoryCommand(
            request.categoryName,
            categoryId,
            request.organizationId
        );

        await commandDispatcher.DispatchAsync<UpdateDeviceCategoryCommand>(command, ct);
        return TypedResults.Ok(new Response(categoryId));
    }

    internal sealed record Response(
        Guid categoryId
    );

    private sealed class Request
    {
        [Required] public string categoryName { get; init; }

        [Required] public Guid categoryId { get; init; }
        [Required] public Guid organizationId { get; init; }
    }
}
