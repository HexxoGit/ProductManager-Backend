using Application.Abstractions;
using Application.Features.RemovedProducts.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.RemovedProducts.Handlers.CommandHandler
{
    public class CreateRemovedProductHandler : IRequestHandler<CreateRemovedProduct, RemovedProduct>
    {
        private readonly IRemovedProductRepository _removedProductRepo;

        public CreateRemovedProductHandler(IRemovedProductRepository repository)
        {
            _removedProductRepo = repository;
        }
        public async Task<RemovedProduct> Handle(CreateRemovedProduct request, CancellationToken cancellationToken)
        {
            var removedProduct = new RemovedProduct
            {
                UserId = request.UserId,
                ProductId = request.ProductId
            };
            return await _removedProductRepo.CreateRemovedProduct(removedProduct);
        }
    }
}
