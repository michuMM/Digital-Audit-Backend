using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.DeviceAssignments.Update;
using DotNetBoilerplate.Core.DeviceAssignments.Exceptions;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.DeviceAssignments;

internal sealed class ModifyDeviceAssignmentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Modify device assignment");
    }

    private static async Task<Results<Ok<Response>, NotFound>> Handle(
        [FromRoute] Guid id,
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new ModifyDeviceAssignmentCommand(id, request.EmployeeId, request.DeviceId);

        await commandDispatcher.DispatchAsync<ModifyDeviceAssignmentCommand>(command, ct);
        return TypedResults.Ok(new Response(id));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {
        [Required] public Guid EmployeeId { get; init; }

        [Required] public Guid DeviceId { get; init; }
    }
}
