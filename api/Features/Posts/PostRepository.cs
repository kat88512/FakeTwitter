using api.Database;
using api.Models;

namespace api.Features.Posts
{
    public class PostRepository : BaseRepository<Post, Guid>
    {
        public PostRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
