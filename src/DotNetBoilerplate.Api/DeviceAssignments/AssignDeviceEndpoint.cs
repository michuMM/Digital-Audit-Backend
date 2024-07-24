using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.DeviceAssignments.Add;
using DotNetBoilerplate.Application.Devices.Add;
using DotNetBoilerplate.Core.DeviceAssignments;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.DeviceAssignments;

internal sealed class AssignDeviceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", Handle)
            .RequireAuthorization()
            .WithSummary("Assign device");
    }

    private static async Task<Ok<Response>> Handle(
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new AssignDeviceCommand(
            request.DeviceId,
            request.EmployeeId,
            request.ReturnDate     
            );

        var result = await commandDispatcher.DispatchAsync<AssignDeviceCommand, Guid>(command, ct);

        return TypedResults.Ok(new Response(result));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {      
        [Required] public Guid DeviceId { get; init; }
        [Required] public Guid EmployeeId { get; init; }        
        [Required] public DateTimeOffset ReturnDate { get; init; }        
    }
}