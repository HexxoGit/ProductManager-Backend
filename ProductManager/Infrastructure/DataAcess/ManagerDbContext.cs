
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAcess
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RemovedProduct> RemovedProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
