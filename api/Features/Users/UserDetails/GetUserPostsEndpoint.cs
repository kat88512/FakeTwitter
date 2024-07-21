using api.Features.Posts;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Features.Users.UserDetails
{
    public class GetUserPostsEndpoint : EndpointWithoutRequest<List<PostDTO>>
    {
        private readonly PostRepository _posts;
        private readonly UserRepository _users;
        private readonly IMapper _mapper;

        public GetUserPostsEndpoint(PostRepository posts, UserRepository users, IMapper mapper)
        {
            _posts = posts;
            _users = users;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("api/users/{userId}/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var userId = Route<Guid>("userId");

            if (!await _users.CheckIfExistsAsync(userId))
            {
                ThrowError("User does not exist");
            }

            var posts = await _posts.GetAllAsync(userId);

            var postsDTO = _mapper.Map<List<PostDTO>>(posts);

            await SendAsync(postsDTO, cancellation: ct);
        }
    }
}
