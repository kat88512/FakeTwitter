using api.Interfaces;

namespace api.Models
{
    public class Post : IAggregateRoot<Guid>
    {
        public const int TextMaxLength = 280;

        public Guid Id { get; private init; }
        public string Text { get; private set; }
        public DateTime DateCreated { get; private set; }

        public Post(Guid id, string text)
        {
            Id = id;
            Text = text;
            DateCreated = DateTime.UtcNow;
        }
    }
}
