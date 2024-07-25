using api.Database;
using api.Features.Posts;
using api.Features.Users;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using IMapper = AutoMapper.IMapper;

namespace api.Features.Feed
{
    public class GetFeedPostsEndpoint : Endpoint<GetFeedPostsRequest, List<PostWithUserDetailsDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFeedPostsEndpoint(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("/api/feed");
        }

        public override async Task HandleAsync(GetFeedPostsRequest req, CancellationToken ct)
        {
            var followedUsersIds = _context
                .Follows.Where(f => f.FollowerId == req.UserId)
                .Select(f => f.FollowedUserId);

            //Future potential for taking first n results here/pagination
            var posts = _context
                .Posts.Join(followedUsersIds, p => p.UserId, uid => uid, (p, _) => p)
                .OrderByDescending(p => p.DateCreated);

            var postsWithUsersDTO = await posts
                .Join(
                    _context.Users,
                    p => p.UserId,
                    u => u.Id,
                    (p, u) =>
                        new PostWithUserDetailsDTO
                        {
                            Id = p.Id,
                            Text = p.Text,
                            DateCreated = p.DateCreated,
                            User = _mapper.Map<UserDTO>(u)
                        }
                )
                .ToListAsync(cancellationToken: ct);

            await SendAsync(postsWithUsersDTO, cancellation: ct);
        }
    }
}
