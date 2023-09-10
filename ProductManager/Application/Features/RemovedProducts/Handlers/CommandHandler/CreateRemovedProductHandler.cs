using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.RemovedProducts.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Handlers.CommandHandler
{
    public class CreateRemovedProductHandler : IRequestHandler<CreateRemovedProduct, RemovedProduct>
    {
        private readonly IRemovedProudctService _removedProductService;

        public CreateRemovedProductHandler(IRemovedProudctService service)
        {
            _removedProductService = service;
        }
        public async Task<RemovedProduct> Handle(CreateRemovedProduct request, CancellationToken cancellationToken)
        {
            return await _removedProductService.CreateRemovedProduct(request);
        }
    }
}
