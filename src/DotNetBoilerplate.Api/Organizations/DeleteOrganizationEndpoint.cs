using DotNetBoilerplate.Application.Organizations.Delete;
using DotNetBoilerplate.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static DotNetBoilerplate.Core.Organizations.Organization;

namespace DotNetBoilerplate.Api.Organizations
{
    internal sealed class DeleteOrganizationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("{organizationId:guid}", Handle)
               .RequireAuthorization()
               .WithSummary("Delete organization by ID");
        }

        private static async Task<Ok<Response>> Handle(
            Guid organizationId,
            [FromServices] ICommandDispatcher commandDispatcher,
            CancellationToken ct
        )
        {
            var command = new DeleteOrganizationCommand(organizationId);

            await commandDispatcher
                .DispatchAsync<DeleteOrganizationCommand>(command, ct);

            return TypedResults.Ok(new Response());
        }
        internal sealed record Response();
    }
}