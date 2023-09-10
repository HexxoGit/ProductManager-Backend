using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.Users.Request.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Handlers.QueriesHandler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUserService _userService;

        public GetUserByIdHandler(IUserService service)
        {
            _userService = service;
        }
        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request.UserId);
        }
    }
}
