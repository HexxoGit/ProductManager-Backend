using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RemovedProducts.Requests.Queries
{
    public class GetRemovedProductsByUsername : IRequest<List<RemovedProduct>>
    {
        public string Username { get; set; }
    }
}
