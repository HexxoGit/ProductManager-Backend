using Application.Features.RemovedProducts.Requests.Commands;
using Domain.Entities;

namespace Application.Abstractions.Infrastructure

{
    public interface IRemovedProudctService
    {
        Task<RemovedProduct> CreateRemovedProduct(CreateRemovedProduct product);
        Task<List<RemovedProduct>> GetAllRemovedProducts();
        Task<List<RemovedProduct>> GetRemovedProductsByUsername(string username);

    }
}
