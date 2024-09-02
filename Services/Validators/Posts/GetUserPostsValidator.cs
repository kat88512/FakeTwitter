using Contracts.Posts;
using Services.DataAccess.Repositories;

namespace Services.Validators.Posts
{
    public class GetUserPostsValidator : Validator<GetUserPostsRequest>
    {
        public GetUserPostsValidator()
        {
            RuleFor(r => r.UserId)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var users = Resolve<UserRepository>();
                        var userExists = await users.CheckIfExistsAsync(id);

                        return userExists;
                    }
                );
        }
    }
}
