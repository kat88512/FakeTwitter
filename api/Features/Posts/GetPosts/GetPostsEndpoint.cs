using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Features.Posts.GetPosts
{
    public class GetPostsEndpoint : EndpointWithoutRequest<IEnumerable<PostDTO>>
    {
        private readonly IPostRepository _posts;
        private readonly IMapper _mapper;

        public GetPostsEndpoint(IPostRepository posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var posts = await _posts.GetAllAsync();

            var postsDTO = _mapper.Map<IEnumerable<PostDTO>>(posts);

            await SendAsync(postsDTO, cancellation: ct);
        }
    }
}
