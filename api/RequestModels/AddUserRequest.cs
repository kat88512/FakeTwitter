using api.Configuration;
using api.Data;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace api.RequestModels
{
    public class AddUserValidator : Validator<AddUserRequest>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(
                    async (email, ct) =>
                    {
                        var context = Resolve<ApplicationDbContext>();
                        var exists = await context.Users.AnyAsync(
                            u => u.EmailAddress == email,
                            cancellationToken: ct
                        );
                        return !exists;
                    }
                );

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(StringLengths.PasswordMinLength);
        }
    };

    public class AddUserRequest
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
