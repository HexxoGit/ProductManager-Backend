using Application.Abstractions.Infrastructure;
using Application.Features.Users.Request.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Handlers.CommandHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService service)
        {
            _userService = service;
        }
        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUser(request);
        }
    }
}
