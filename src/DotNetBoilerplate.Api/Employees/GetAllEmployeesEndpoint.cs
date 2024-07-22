using DotNetBoilerplate.Application.Employees;
using DotNetBoilerplate.Application.Employees.Get;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Employees
{
    public class GetAllEmployeesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("", Handle)
                .RequireAuthorization()
                .WithSummary("Get all employees");
        }

        private static async Task<Ok<List<EmployeeDto>>> Handle(
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetAllEmployeesQuery();

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
