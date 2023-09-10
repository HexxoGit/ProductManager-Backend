using Application.Features.Users.Request.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Infrastructure
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUser userRequest);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<string> LoginUser(AuthenticateUser user);
    }
}
