using api.Database;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Posts
{
    public class PostRepository : BaseRepository<Post, Guid>
    {
        public PostRepository(ApplicationDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
