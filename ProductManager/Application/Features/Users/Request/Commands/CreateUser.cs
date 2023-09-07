using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Request.Commands
{
    public class CreateUser : IRequest<User>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
