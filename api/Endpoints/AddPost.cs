using api.Models;
using api.RequestModels;
using api.ResponseModels;
using FastEndpoints;

namespace api.Endpoints
{
    public class AddPost : Endpoint<AddPostRequest, PostDTO>
    {
        public override void Configure()
        {
            Post("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddPostRequest req, CancellationToken ct)
        {
            var post = new Post(req.Id, req.Text);

            await SendAsync(new()
            {
                Id = post.Id,
                DateCreated = post.DateCreated,
                Text = post.Text,
            });
        }
    }
}
