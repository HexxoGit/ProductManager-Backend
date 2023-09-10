using Application.Features.Users.Request.Commands;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using ProductManagerApi.Abstractions;

namespace ProductManagerApi.EndpointDefinitions
{
    public class UserEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var userManagement = app.MapGroup("/api/user");

            userManagement.MapPost("/login", UserLogin);
        }

        private async Task<IResult> UserLogin(IMediator mediator, AuthenticateUser command)
        {
            return TypedResults.Ok(await mediator.Send(command));
        }
    }
}
