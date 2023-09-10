using Application.Abstractions.Infrastructure;
using Application.Abstractions.Persistance;
using Application.Features.RemovedProducts.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Services.RemovedProductService
{
    public class RemovedProductService : IRemovedProudctService
    {
        private readonly IRemovedProductRepository _removedProductRepo;

        public RemovedProductService(IRemovedProductRepository repo)
        {
            _removedProductRepo = repo;
        }

        public async Task<RemovedProduct> CreateRemovedProduct(CreateRemovedProduct product)
        {
            var removedProduct = new RemovedProduct
            {
                Username = product.Username,
                ProductName = product.ProductName
            };
            return await _removedProductRepo.CreateRemovedProduct(removedProduct);
        }

        public async Task<List<RemovedProduct>> GetAllRemovedProducts()
        {
            return await _removedProductRepo.GetRemovedProducts();
        }

        public async Task<List<RemovedProduct>> GetRemovedProductsByUsername(string username)
        {
            return await _removedProductRepo.GetRemovedProductsByUsername(username);
        }
    }
}
