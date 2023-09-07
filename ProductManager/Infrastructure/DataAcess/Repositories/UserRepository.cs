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

        public async Task<User> CreateUser(User user)
        {
            _managerDbContext.Users.Add(user);
            await _managerDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _managerDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _managerDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
