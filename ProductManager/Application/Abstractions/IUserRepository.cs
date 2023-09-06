using Domain.Entities;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> FindByName(string username);
    }
}
