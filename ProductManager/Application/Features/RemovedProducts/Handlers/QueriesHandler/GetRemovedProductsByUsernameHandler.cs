using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.RemovedProducts.Requests.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Handlers.QueriesHandler
{
    public class GetRemovedProductsByUsernameHandler : IRequestHandler<GetRemovedProductsByUsername, List<RemovedProduct>>
    {
        private readonly IRemovedProudctService _removedProductService;

        public GetRemovedProductsByUsernameHandler(IRemovedProudctService service)
        {
            _removedProductService = service;
        }
        public async Task<List<RemovedProduct>> Handle(GetRemovedProductsByUsername request, CancellationToken cancellationToken)
        {
            return await _removedProductService.GetRemovedProductsByUsername(request.Username);
        }
    }
}
