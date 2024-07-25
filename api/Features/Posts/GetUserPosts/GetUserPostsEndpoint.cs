using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Features.Posts.GetUserPosts
{
    public class GetUserPostsEndpoint : Endpoint<GetUserPostsRequest, List<PostDTO>>
    {
        private readonly PostRepository _posts;
        private readonly IMapper _mapper;

        public GetUserPostsEndpoint(PostRepository posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("api/users/{UserId}/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetUserPostsRequest req, CancellationToken ct)
        {
            var userId = req.UserId;

            var posts = await _posts.GetAllAsync(userId);

            var postsDTO = _mapper.Map<List<PostDTO>>(posts);

            await SendAsync(postsDTO, cancellation: ct);
        }
    }
}
