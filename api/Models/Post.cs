using api.Shared.Interfaces;

namespace api.Models
{
    public class Post : IAggregateRoot<Guid>
    {
        public const int TextMaxLength = 280;

        public Guid Id { get; private init; }
        public Guid UserId { get; private init; }
        public string Text { get; private set; }
        public DateTime DateCreated { get; private set; }

        public Post(Guid id, Guid userId, string text)
        {
            Id = id;
            UserId = userId;
            Text = text;
            DateCreated = DateTime.UtcNow;
        }
    }
}
