namespace Contracts.Follows
{
    public class FollowDTO
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedUserId { get; set; }
    }
}
