using api.Database;
using api.Models;
using api.Shared.Repositories;

namespace api.Features.Users
{
    public class UserRepository : BaseRepository<User, Guid>
    {
        public UserRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
