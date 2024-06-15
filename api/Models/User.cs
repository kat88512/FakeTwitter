using api.Shared;
using api.Shared.Interfaces;

namespace api.Models
{
    public class User : IAggregateRoot<Guid>
    {
        public const int PasswordMinLength = 10;
        public const int PasswordHashMaxLength = StringLengths.ShortString;

        public Guid Id { get; private init; }
        public string EmailAddress { get; private set; }
        public string PasswordHash { get; private set; }

        public User(Guid id, string emailAddress, string passwordHash)
        {
            Id = id;
            EmailAddress = emailAddress;
            PasswordHash = passwordHash;
        }
    }
}
