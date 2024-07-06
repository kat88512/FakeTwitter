using api.Database;
using api.Models;

namespace api.Features.Users
{
    public class UserRepository : BaseRepository<User, Guid>
    {
        public UserRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
