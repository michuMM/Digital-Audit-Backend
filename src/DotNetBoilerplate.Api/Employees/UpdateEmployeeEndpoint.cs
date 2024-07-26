using System.ComponentModel.DataAnnotations;
using DotNetBoilerplate.Application.Employees.Update;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Employees;

internal sealed class UpdateEmployeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Update employee");
    }

    private static async Task<Results<Ok<Response>, NotFound>> Handle(
        [FromRoute] Guid id,
        [FromBody] Request request,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new UpdateEmployeeCommand(
            id, 
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Phone);

        await commandDispatcher.DispatchAsync<UpdateEmployeeCommand>(command, ct);
        return TypedResults.Ok(new Response(id));
    }

    internal sealed record Response(
        Guid id
    );

    private sealed class Request
    {
        [Required] public string FirstName { get; init; }
        [Required] public string LastName { get; init; }
        [Required] public string Email { get; init; }
        [Required] public string Phone { get; init; }
    }
}
