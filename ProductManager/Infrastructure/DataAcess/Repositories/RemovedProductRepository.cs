using Application.Abstractions.Persistance;
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

        public Task<List<RemovedProduct>> GetRemovedProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RemovedProduct>> GetRemovedProductsByUsername(string username)
        {
            var removedProducts =  _managerDbContext.RemovedProducts
                .Where(x => x.Username == username)
                .ToList();
            await _managerDbContext.SaveChangesAsync();
            return removedProducts;
        }
    }
}
