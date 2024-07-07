using api.Database;
using api.Models;

namespace api.Features.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> CheckIfExistsAsync(string email);
    }
}
