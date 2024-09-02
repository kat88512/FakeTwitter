namespace Contracts.Users.Register
{
    public class RegisterRequest
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
