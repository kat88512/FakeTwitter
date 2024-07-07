using api.Models;
using api.Services.PasswordHasher;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Features.Users.AddUser
{
    public class AddUserEndpoint : Endpoint<AddUserRequest, UserDTO>
    {
        private readonly IUserRepository _users;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public AddUserEndpoint(
            IUserRepository users,
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

        public override async Task HandleAsync(AddUserRequest req, CancellationToken ct)
        {
            var hashedPassword = _passwordHasher.HashPassword(req.Password);

            var user = new User(req.Id, req.EmailAddress, hashedPassword);

            await _users.AddAsync(user);

            var userDTO = _mapper.Map<UserDTO>(user);

            await SendAsync(userDTO, cancellation: ct);
        }
    }
}
