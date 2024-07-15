using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Devices.Add;
using DotNetBoilerplate.Core.Devices;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.Devices;

internal sealed class AddDeviceEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", Handle)          
            .WithSummary("Add device");
    }

    private static async Task<Ok<Response>> Handle(
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new AddDeviceCommand(
            request.Name, 
            request.OrganizationId, 
            request.CategoryId,
            request.SerialNumber,
            request.DateOfPurchase,
            request.Localization,
            request.Status
            );

        var result = await commandDispatcher.DispatchAsync<AddDeviceCommand, Guid>(command, ct);

        return TypedResults.Ok(new Response(result));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {
        [Required] public string Name { get; init; }
        [Required] public Guid OrganizationId { get; init; }
        [Required] public Guid CategoryId { get; init; }
        [Required] public String SerialNumber { get; init; }
        [Required] public DateTime DateOfPurchase { get; init; }
        [Required] public String Localization { get; init; }
        [Required] public String Status { get; init; }
    }
}