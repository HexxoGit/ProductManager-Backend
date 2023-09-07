using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Request.Queries
{
    public class GetUserById : IRequest<User>
    {
        public int UserId { get; set; }
    }
}
