using api.Database;
using api.Models;
using api.Shared;
using api.Shared.Interfaces;
using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Users.AddUser
{
    public class AddUserValidator : Validator<AddUserRequest>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.EmailAddress)
                .NotEmpty()
                .MaximumLength(StringLengths.MediumString)
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
                .MinimumLength(User.PasswordMinLength)
                .MaximumLength(StringLengths.ShortString);

            RuleFor(u => u.Id)
                .MustAsync(
                    async (id, ct) =>
                    {
                        var users = Resolve<IRepository<User, Guid>>();
                        var exists = await users.CheckIfExistsAsync(id);

                        return !exists;
                    }
                );
        }
    };

    public class AddUserRequest
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
