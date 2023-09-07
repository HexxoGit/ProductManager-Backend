using Application.Features.Users.Request.Commands;
using MediatR;
using ProductManagerApi.Abstractions;

namespace ProductManagerApi.EndpointDefinitions
{
    public class UserEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var userManagement = app.MapGroup("/api/user");

            userManagement.MapPost("/login", async (AuthenticateUser command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            });
        }
    }
}
