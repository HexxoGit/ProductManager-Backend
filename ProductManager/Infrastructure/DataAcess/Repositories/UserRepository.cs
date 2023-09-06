using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAcess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ManagerDbContext _managerDbContext;

        public UserRepository(ManagerDbContext context)
        {
            _managerDbContext = context;
        }
        public async Task<User> FindByName(string username)
        {
            var user = await _managerDbContext.Users
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }
    }
}
