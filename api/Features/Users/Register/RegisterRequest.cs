using api.Models;
using api.Shared;
using FastEndpoints;

namespace api.Features.Users.AddUser
{
    public class RegisterValidator : Validator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.EmailAddress)
                .NotEmpty()
                .MaximumLength(StringLengths.MediumString)
                .EmailAddress()
                .MustAsync(
                    async (email, ct) =>
                    {
                        var users = Resolve<IUserRepository>();
                        var exists = await users.CheckIfExistsAsync(email);

                        return !exists;
                    }
                );

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(User.PasswordMinLength)
                .MaximumLength(StringLengths.ShortString);

            RuleFor(u => u.Id)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var users = Resolve<IUserRepository>();
                        var exists = await users.CheckIfExistsAsync(id);

                        return !exists;
                    }
                );
        }
    };

    public class RegisterRequest
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
