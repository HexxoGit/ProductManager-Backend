using Application.Abstractions.Persistance;
using Application.Features.Users.Request.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Handlers.QueriesHandler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository repo)
        {
            _userRepository = repo;
        }
        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.UserId);
        }
    }
}
