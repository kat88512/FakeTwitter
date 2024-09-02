using Api.Models;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace Api.Features.Follows.FollowUser
{
    public class FollowUserEndpoint : Endpoint<FollowUserRequest, FollowDTO>
    {
        private readonly FollowRepository _follows;
        private readonly IMapper _mapper;

        public FollowUserEndpoint(FollowRepository follows, IMapper mapper)
        {
            _follows = follows;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Post("/api/follows");
        }

        public override async Task HandleAsync(FollowUserRequest req, CancellationToken ct)
        {
            var follow = new Follow(req.UserId, req.TargetUserId);

            await _follows.AddAsync(follow);

            var followDTO = _mapper.Map<FollowDTO>(follow);

            await SendAsync(followDTO, cancellation: ct);
        }
    }
}
