namespace Contracts.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
