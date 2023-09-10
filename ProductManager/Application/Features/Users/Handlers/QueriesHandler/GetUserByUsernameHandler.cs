using Application.Abstractions.Infrastructure;
using Application.Features.Users.Request.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Handlers.QueriesHandler
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsername, User>
    {
        private readonly IUserService _userService;

        public GetUserByUsernameHandler(IUserService service)
        {
            _userService = service;
        }
        public async Task<User> Handle(GetUserByUsername request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByUsername(request.Username);
        }
    }
}
