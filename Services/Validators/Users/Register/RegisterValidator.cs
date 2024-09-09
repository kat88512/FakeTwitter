using Contracts.Users.Register;
using Domain.Users;
using Services.Consts;
using Services.DataAccess.Repositories;

namespace Services.Validators.Users.Register
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
                        var users = Resolve<UserRepository>();
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
                        var users = Resolve<UserRepository>();
                        var exists = await users.CheckIfExistsAsync(id);

                        return !exists;
                    }
                );
        }
    };
}
