using api.Data;
using api.Interfaces;
using api.Models;
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
                .MinimumLength(User.PasswordMinLength);

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
