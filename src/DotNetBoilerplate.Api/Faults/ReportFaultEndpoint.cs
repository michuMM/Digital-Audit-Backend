using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Faults.Report;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.Faults;

internal sealed class ReportFaultEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", Handle)
            .RequireAuthorization()
            .WithSummary("Report fault");
    }

    private static async Task<Ok<Response>> Handle(
        [FromBody] Request request,        
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new ReportFaultCommand(
            request.DeviceId,
            request.ReporterId, 
            request.Name, 
            request.Description, 
            request.DeviceStatus,
            request.DateIssuedForRepair,
            request.PlannedReturnDate,
            request.RepairDate


            );

        var result = await commandDispatcher.DispatchAsync<ReportFaultCommand, Guid>(command, ct);

        return TypedResults.Ok(new Response(result));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {
        [Required] public Guid DeviceId { get; init; }

        [Required] public Guid ReporterId { get; init; }

        [Required] public string Name { get; init; }

        [Required] public string Description{ get; init; }

        [Required] public string DeviceStatus { get; init; }

        public DateTimeOffset? DateIssuedForRepair { get; init; }

        public DateTimeOffset? PlannedReturnDate { get; init; }

        public DateTimeOffset? RepairDate { get; init; }
    }
}