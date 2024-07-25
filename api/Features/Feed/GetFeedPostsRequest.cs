using System.IdentityModel.Tokens.Jwt;
using FastEndpoints;

namespace api.Features.Feed
{
    public class GetFeedPostsRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
    }
}
