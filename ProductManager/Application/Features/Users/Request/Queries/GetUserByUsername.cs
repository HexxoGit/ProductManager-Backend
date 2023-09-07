using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Request.Queries
{
    public class GetUserByUsername : IRequest<User>
    {
        public string? Username {  get; set; }    
    }
}
