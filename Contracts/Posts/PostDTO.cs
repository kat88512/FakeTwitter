namespace Contracts.Posts
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}
