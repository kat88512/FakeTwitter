namespace Contracts.Feed
{
    public class GetFeedPostsRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
    }
}
