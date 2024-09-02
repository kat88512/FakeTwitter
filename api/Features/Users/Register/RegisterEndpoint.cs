using Api.Models;
using Api.Services.PasswordHasher;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace Api.Features.Users.Register
{
    public class RegisterEndpoint : Endpoint<RegisterRequest, UserDTO>
    {
        private readonly UserRepository _users;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterEndpoint(
            UserRepository users,
            IMapper mapper,
            IPasswordHasher passwordHasher
        )
        {
            _users = users;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public override void Configure()
        {
            Post("api/register");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
        {
            var hashedPassword = _passwordHasher.HashPassword(req.Password);

            var user = new User(req.Id, req.EmailAddress, hashedPassword);

            await _users.AddAsync(user);

            var userDTO = _mapper.Map<UserDTO>(user);

            await SendAsync(userDTO, cancellation: ct);
        }
    }
}
