using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Devices.Relocate;
using DotNetBoilerplate.Core.Devices.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.Devices;

internal sealed class RelocateDeviceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Relocate device");
    }

    private static async Task<Results<Ok<Response>, NotFound>> Handle(
        [FromRoute] Guid id,
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new RelocateDeviceCommand(id, request.Localization);

        await commandDispatcher.DispatchAsync<RelocateDeviceCommand>(command, ct);
        return TypedResults.Ok(new Response(id));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {
        [Required] public string Localization { get; init; }
    }
}
