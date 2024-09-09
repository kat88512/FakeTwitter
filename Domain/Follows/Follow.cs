namespace Domain.Follows
{
    public class Follow : IAggregateRoot<(Guid, Guid)>
    {
        public (Guid, Guid) Id => (FollowerId, FollowedUserId);
        public Guid FollowerId { get; private init; }
        public Guid FollowedUserId { get; private init; }

        public Follow(Guid followerId, Guid followedUserId)
        {
            FollowerId = followerId;
            FollowedUserId = followedUserId;
        }
    }
}
