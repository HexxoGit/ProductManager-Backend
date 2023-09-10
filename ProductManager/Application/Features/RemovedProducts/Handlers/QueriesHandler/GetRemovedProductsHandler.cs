using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.RemovedProducts.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Handlers.QueriesHandler
{
    public class GetRemovedProductsHandler : IRequestHandler<GetRemovedProducts, ICollection<RemovedProduct>>
    {
        private readonly IRemovedProudctService _removedProductService;

        public GetRemovedProductsHandler(IRemovedProudctService service)
        {
            _removedProductService = service;
        }
        public async Task<ICollection<RemovedProduct>> Handle(GetRemovedProducts request, CancellationToken cancellationToken)
        {
            return await _removedProductService.GetAllRemovedProducts();
        }
    }
}
