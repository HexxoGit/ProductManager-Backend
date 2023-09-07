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
