using System.IdentityModel.Tokens.Jwt;
using FastEndpoints;

namespace Api.Features.Feed
{
    public class GetFeedPostsRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
    }
}
