using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Requests.Queries
{
    public class GetRemovedProductsByUsername : IRequest<List<RemovedProduct>>
    {
        public string Username { get; set; }
    }
}
