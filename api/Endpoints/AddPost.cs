using api.Interfaces;
using api.Models;
using api.RequestModels;
using api.ResponseModels;
using FastEndpoints;

namespace api.Endpoints
{
    public class AddPost : Endpoint<AddPostRequest, PostDTO>
    {
        private readonly IRepository<Post, Guid> _postRepository;

        public AddPost(IRepository<Post, Guid> postRepository)
        {
            _postRepository = postRepository;
        }

        public override void Configure()
        {
            Post("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddPostRequest req, CancellationToken ct)
        {
            var post = new Post(req.Id, req.Text);

            await _postRepository.AddAsync(post);

            await SendAsync(
                new()
                {
                    Id = post.Id,
                    DateCreated = post.DateCreated,
                    Text = post.Text,
                }
            );
        }
    }
}
