using Contracts.Posts;
using Services.DataAccess.Repositories;
using IMapper = AutoMapper.IMapper;

namespace Services.Endpoints.Posts
{
    public class AddPostEndpoint : Endpoint<AddPostRequest, PostDTO>
    {
        private readonly PostRepository _posts;
        private readonly IMapper _mapper;

        public AddPostEndpoint(PostRepository posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Post("/api/posts");
        }

        public override async Task HandleAsync(AddPostRequest req, CancellationToken ct)
        {
            var post = new Post(req.Id, req.UserId, req.Text);

            await _posts.AddAsync(post);

            var postDTO = _mapper.Map<PostDTO>(post);

            await SendAsync(postDTO, cancellation: ct);
        }
    }
}
