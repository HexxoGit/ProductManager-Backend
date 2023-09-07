using Application.Abstractions;
using Application.Features.Users.Request.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Handlers.CommandHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository repo)
        {
            _userRepository = repo;
        }
        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Username = request.Username,
                Password = request.Password
            };
            return await _userRepository.CreateUser(newUser);
        }
    }
}
