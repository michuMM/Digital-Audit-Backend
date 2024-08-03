using DotNetBoilerplate.Application.Faults;
using DotNetBoilerplate.Application.Faults.Read;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBoilerplate.Api.Faults
{
    public class GetAllFaultsByOrganizationIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("fromOrganization", Handle)
                .RequireAuthorization()
                .WithSummary("Get all faults by organization id");
        }

        private static async Task<Ok<List<FaultDto>>> Handle(
            [FromRoute] Guid organizationId,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetAllFaultsByOrganizationIdQuery(organizationId);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}
