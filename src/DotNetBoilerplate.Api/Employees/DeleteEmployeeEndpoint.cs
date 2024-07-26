using DotNetBoilerplate.Application.Employees.Delete;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static DotNetBoilerplate.Core.Employees.Employee;

namespace DotNetBoilerplate.Api.Employees;

internal sealed class DeleteEmployeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("{id:guid}", Handle)
            .RequireAuthorization()
            .WithSummary("Delete employee by ID");
    }

    private static async Task<Ok<Response>> Handle(
        Guid id,
        [FromServices] ICommandDispatcher commandDispatcher,
        CancellationToken ct
    )
    {
        var command = new DeleteEmployeeCommand(id);

        await commandDispatcher.DispatchAsync<DeleteEmployeeCommand>(command, ct);

        return TypedResults.Ok(new Response());
    }

    internal sealed record Response();
}
