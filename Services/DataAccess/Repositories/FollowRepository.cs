﻿using Domain.Follows;
using Microsoft.EntityFrameworkCore;

namespace Services.DataAccess.Repositories
{
    public class FollowRepository : BaseRepository<Follow, (Guid, Guid)>
    {
        public FollowRepository(ApplicationDbContext context)
            : base(context) { }

        public override async Task<Follow?> GetByIdAsync((Guid, Guid) id)
        {
            return await _dbSet.FirstOrDefaultAsync(e =>
                e.FollowerId == id.Item1 && e.FollowedUserId == id.Item2
            );
        }

        public override async Task<bool> CheckIfExistsAsync((Guid, Guid) id)
        {
            return await _dbSet.AnyAsync(e =>
                e.FollowerId == id.Item1 && e.FollowedUserId == id.Item2
            );
        }
    }
}
