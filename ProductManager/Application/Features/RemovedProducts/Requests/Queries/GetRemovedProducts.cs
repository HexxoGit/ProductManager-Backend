using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Requests.Queries
{
    public class GetRemovedProducts : IRequest<List<RemovedProduct>>
    {
    }
}
