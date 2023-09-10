using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.Users.Request.Commands;
using MediatR;

namespace Application.Features.Users.Handlers.CommandHandler
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUser, string>
    {
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IUserService service)
        {
           _userService = service;
        }
        
        public async Task<string> Handle(AuthenticateUser request, CancellationToken cancellationToken)
        {
            return await _userService.LoginUser(request);
        }
    }
}
