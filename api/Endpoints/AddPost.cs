using api.Interfaces;
using api.Models;
using api.RequestModels;
using api.ResponseModels;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Endpoints
{
    public class AddPost : Endpoint<AddPostRequest, PostDTO>
    {
        private readonly IRepository<Post, Guid> _posts;
        private readonly IMapper _mapper;

        public AddPost(IRepository<Post, Guid> posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Post("/api/posts");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddPostRequest req, CancellationToken ct)
        {
            var post = new Post(req.Id, req.Text);

            await _posts.AddAsync(post);

            var postDTO = _mapper.Map<PostDTO>(post);

            await SendAsync(postDTO, cancellation: ct);
        }
    }
}
