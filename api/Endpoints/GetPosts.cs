using api.Data;
using api.ResponseModels;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using IMapper = AutoMapper.IMapper;

namespace api.Endpoints
{
    public class GetPosts : EndpointWithoutRequest<IEnumerable<PostDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPosts(ApplicationDbContext context, IMapper mapper)
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
            var posts = await _context.Posts.ToListAsync(cancellationToken: ct);

            var postsDTO = _mapper.Map<IEnumerable<PostDTO>>(posts);

            await SendAsync(postsDTO, cancellation: ct);
        }
    }
}
