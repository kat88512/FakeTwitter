using FakeTwitter.ResponseModels;
using FastEndpoints;

namespace FakeTwitter.Endpoints
{
    public class GetPosts : EndpointWithoutRequest<List<PostDTO>>
    {
        public override void Configure()
        {
            Get("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(GetMockPosts(), cancellation: ct);
        }

        private List<PostDTO> GetMockPosts()
        {
            var mockPosts = new List<PostDTO>()
            {
                new() { Id = Guid.NewGuid(), DateCreated = new DateTime(2024, 3, 3), Text = "Text 1" },
                new() { Id = Guid.NewGuid(), DateCreated = new DateTime(2024, 3, 4), Text = "Text 2" },
                new() { Id = Guid.NewGuid(), DateCreated = new DateTime(2024, 3, 5), Text = "Text 3" },
            };

            return mockPosts;
        }
    }
}
