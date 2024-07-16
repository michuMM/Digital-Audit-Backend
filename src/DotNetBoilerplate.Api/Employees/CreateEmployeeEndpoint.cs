using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Employees.Create;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DotNetBoilerplate.Api.Employees;

internal sealed class CreateEmployeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", Handle)
            .RequireAuthorization()
            .WithSummary("Create organization");
    }

    private static async Task<Ok<Response>> Handle(
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new CreateEmployeeCommand(request.First_name, request.Last_name, request.Email, request.Phone);

        var result = await commandDispatcher.DispatchAsync<CreateEmployeeCommand, Guid>(command, ct);

        return TypedResults.Ok(new Response(result));
    }

    internal sealed record Response(
        Guid Id
    );

    private sealed class Request
    {
        [Required] public string First_name { get; init; }

        [Required] public string Last_name { get; init; }

        [Required] public string Email { get; init; }

        [Required] public string Phone { get; init; }
    }
}