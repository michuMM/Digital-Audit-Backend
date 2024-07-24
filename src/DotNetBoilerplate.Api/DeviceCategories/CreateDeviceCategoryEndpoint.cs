using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.DeviceCategories.Create;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.DeviceCategories;

internal sealed class CreateDeviceCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", Handle)
            .RequireAuthorization()
            .WithSummary("Create device category");
    }

    private static async Task<Ok<Response>> Handle (
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new CreateDeviceCategoryCommand(request.OrganizationId, request.CategoryName);

        var result = await commandDispatcher.DispatchAsync<CreateDeviceCategoryCommand, Guid>(command, ct);

        return TypedResults.Ok(new Response(result));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {
        [Required] public Guid OrganizationId { get; init; }

        [Required] public string CategoryName { get; init; }
    }
}
