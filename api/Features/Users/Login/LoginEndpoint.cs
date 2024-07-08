using System.IdentityModel.Tokens.Jwt;
using api.Configuration.Options;
using api.Features.Users;
using api.Features.Users.Login;
using api.Services.PasswordHasher;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.Extensions.Options;

namespace Features.Users.Login
{
    public class LoginEndpoint : Endpoint<LoginRequest>
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _users;

        public LoginEndpoint(
            IOptions<JwtOptions> jwtOptions,
            IPasswordHasher passwordHasher,
            IUserRepository users
        )
        {
            _jwtOptions = jwtOptions.Value;
            _passwordHasher = passwordHasher;
            _users = users;
        }

        public override void Configure()
        {
            Post("/api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            var user = await _users.GetByEmailAsync(req.EmailAddress);

            if (user is null)
            {
                ThrowError("The supplied credentials are invalid!");
            }

            if (_passwordHasher.VerifyPassword(user.PasswordHash, req.Password))
            {
                var jwtToken = JwtBearer.CreateToken(o =>
                {
                    o.SigningKey = _jwtOptions.Key;
                    o.ExpireAt = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationPeriodInMinutes);
                    o.User.Claims.Add((JwtRegisteredClaimNames.Sub, user.Id.ToString()));
                });

                await SendAsync(new { req.EmailAddress, Token = jwtToken });
            }
            else
                ThrowError("The supplied credentials are invalid!");
        }
    }
}
