namespace Contracts.Posts
{
    public class AddPostRequest
    {
        [FromClaim(JwtRegisteredClaimNames.Sub)]
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
