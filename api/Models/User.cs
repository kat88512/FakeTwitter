using api.Interfaces;

namespace api.Models
{
    public class User : IAggregateRoot<Guid>
    {
        public Guid Id { get; private init; }
        public string EmailAddress { get; private set; }
        public string Password { get; private set; }

        public User(Guid id, string emailAddress, string password)
        {
            Id = id;
            EmailAddress = emailAddress;
            Password = password;
        }
    }
}
