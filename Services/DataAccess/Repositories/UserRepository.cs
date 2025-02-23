﻿using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Services.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>
    {
        public UserRepository(ApplicationDbContext context)
            : base(context) { }

        public virtual async Task<bool> CheckIfExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.EmailAddress == email);
        }

        public virtual async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.EmailAddress == email);
        }
    }
}
