using DotNetBoilerplate.Application.Organizations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DotNetBoilerplate.Shared.Abstractions.Queries;
using DotNetBoilerplate.Application.Organizations.Read;

namespace DotNetBoilerplate.Api.Organizations
{
    public class GetOrganizationByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("{id:guid}", Handle)
                .RequireAuthorization()
                .WithSummary("Get organization by id");
        }

        public static async Task<Ok<OrganizationDto>> Handle(
            [FromRoute] Guid id,
            [FromServices] IQueryDispatcher queryDispatcher,
            CancellationToken ct
        )
        {
            var query = new GetOrganizationByIdQuery(id);

            var result = await queryDispatcher.QueryAsync(query, ct);

            return TypedResults.Ok(result);
        }
    }
}