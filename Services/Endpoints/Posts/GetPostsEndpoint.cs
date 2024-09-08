using Contracts.Posts;
using Contracts.Users;
using Microsoft.EntityFrameworkCore;
using Services.DataAccess;
using IMapper = AutoMapper.IMapper;

namespace Services.Endpoints.Posts
{
    public class GetPostsEndpoint : EndpointWithoutRequest<IEnumerable<PostWithUserDetailsDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsEndpoint(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var postsWithUsersDTO = await _context
                .Posts.Join(
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
