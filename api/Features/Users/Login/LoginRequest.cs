using Api.Shared;
using FastEndpoints;

namespace Api.Features.Users.Login
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

    public class LoginRequest
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
