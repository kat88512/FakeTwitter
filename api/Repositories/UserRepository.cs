using api.Data;
using api.Models;

namespace api.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>
    {
        public UserRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
