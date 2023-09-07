using Application.Abstractions;
using Application.Features.RemovedProducts.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Handlers.QueriesHandler
{
    public class GetRemovedProductsHandler : IRequestHandler<GetRemovedProducts, ICollection<RemovedProduct>>
    {
        private readonly IRemovedProductRepository _removedProductRepo;

        public GetRemovedProductsHandler(IRemovedProductRepository repo)
        {
            _removedProductRepo = repo;
        }
        public async Task<ICollection<RemovedProduct>> Handle(GetRemovedProducts request, CancellationToken cancellationToken)
        {
            return await _removedProductRepo.GetRemovedProducts();
        }
    }
}
