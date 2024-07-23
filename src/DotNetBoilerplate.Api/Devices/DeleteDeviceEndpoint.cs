using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Devices.Delete;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.Devices;

internal sealed class DeleteDeviceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("{deviceId:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Delete device by ID");
    }

    private static async Task<Ok<Response>> Handle(
        Guid deviceId,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new DeleteDeviceCommand(deviceId);

        await commandDispatcher
                .DispatchAsync<DeleteDeviceCommand>(command, ct);

        return TypedResults.Ok(new Response());
    }

    internal sealed record Response();
}