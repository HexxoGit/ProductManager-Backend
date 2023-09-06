using Application.Abstractions;
using Domain.Entities;

namespace Infrastructure.DataAcess.Repositories
{
    public class RemovedProductRepository : IRemovedProductRepository
    {
        private readonly ManagerDbContext _managerDbContext;

        public RemovedProductRepository(ManagerDbContext context)
        {
            _managerDbContext = context;
        }
        public async Task<RemovedProduct> CreateRemovedProduct(RemovedProduct product)
        {
            _managerDbContext.RemovedProducts.Add(product);
            await _managerDbContext.SaveChangesAsync();
            return product;
        }

        public Task<ICollection<RemovedProduct>> GetAllRemovedProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RemovedProduct>> GetAllRemovedProductsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
