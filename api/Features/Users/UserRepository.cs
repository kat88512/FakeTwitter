using api.Database;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Users
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context) { }

        public async Task<bool> CheckIfExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.EmailAddress == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.EmailAddress == email);
        }
    }
}
