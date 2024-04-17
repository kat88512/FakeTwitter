using api.Interfaces;
using api.Models;
using api.ResponseModels;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Endpoints
{
    public class GetPosts : EndpointWithoutRequest<IEnumerable<PostDTO>>
    {
        private readonly IRepository<Post, Guid> _postRepository;
        private readonly IMapper _mapper;

        public GetPosts(IRepository<Post, Guid> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var posts = await _postRepository.GetAllAsync();

            var postsDTO = _mapper.Map<IEnumerable<PostDTO>>(posts);

            await SendAsync(postsDTO, cancellation: ct);
        }
    }
}
