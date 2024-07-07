using api.Database;
using api.Models;

namespace api.Features.Posts
{
    public interface IPostRepository : IRepository<Post, Guid> { }
}
