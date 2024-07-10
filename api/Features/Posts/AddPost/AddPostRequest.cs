using System.IdentityModel.Tokens.Jwt;
using api.Models;
using FastEndpoints;

namespace api.Features.Posts.AddPost
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

    public class AddPostRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
