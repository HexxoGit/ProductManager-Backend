using Domain.Entities;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
    }
}
