namespace Contracts.Follows
{
    public class FollowUserRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
