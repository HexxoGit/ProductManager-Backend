using Application.Abstractions;
using Application.Features.Users.Request.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handlers.QueriesHandler
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsername, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUsernameHandler(IUserRepository repo)
        {
            _userRepository = repo;
        }
        public async Task<User> Handle(GetUserByUsername request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUsername(request.Username);
        }
    }
}
