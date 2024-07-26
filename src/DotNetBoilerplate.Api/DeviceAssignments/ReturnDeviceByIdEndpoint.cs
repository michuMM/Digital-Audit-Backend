using DotNetBoilerplate.Application.DeviceAssignments.Delete;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.DeviceAssignments;

internal sealed class ReturnDeviceByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("{deviceAssignmentId:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Return device by ID");
    }

    private static async Task<Ok<Response>> Handle(
        Guid deviceAssignmentId,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new ReturnDeviceCommand(deviceAssignmentId);

        await commandDispatcher
            .DispatchAsync<ReturnDeviceCommand, Guid>(command, ct);

        return TypedResults.Ok(new Response());
    }
    internal sealed record Response();
}