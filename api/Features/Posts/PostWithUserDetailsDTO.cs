using api.Features.Users;

namespace api.Features.Posts
{
    public class PostWithUserDetailsDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public UserDTO User { get; set; }
    }
}
