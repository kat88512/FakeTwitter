using Contracts.Users.Login;
using Services.Consts;

namespace Services.Validators.Users.Login
{
    public class LoginValidator : Validator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(u => u.EmailAddress)
                .NotEmpty()
                .MaximumLength(StringLengths.MediumString)
                .EmailAddress();

            RuleFor(u => u.Password).NotEmpty().MaximumLength(StringLengths.ShortString);
        }
    }
}
