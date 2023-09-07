using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Request.Queries
{
    public class GetUserByUsername : IRequest<User>
    {
        public string? Username {  get; set; }    
    }
}
