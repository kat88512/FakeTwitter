using Contracts.Posts;
using Domain.Posts;
using Services.DataAccess.Repositories;

namespace Services.Validators.Posts
{
    public class AddPostValidator : Validator<AddPostRequest>
    {
        public AddPostValidator()
        {
            RuleFor(p => p.Text).NotEmpty().MaximumLength(Post.TextMaxLength);

            RuleFor(p => p.Id)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var posts = Resolve<PostRepository>();
                        var exists = await posts.CheckIfExistsAsync(id);

                        return !exists;
                    }
                );
        }
    }
}
