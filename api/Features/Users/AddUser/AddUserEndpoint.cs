using api.Models;
using api.Shared.Extensions;
using api.Shared.Interfaces;
using CryptoHelper;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Features.Users.AddUser
{
    public class AddUserEndpoint : Endpoint<AddUserRequest, UserDTO>
    {
        private readonly IRepository<User, Guid> _users;
        private readonly IMapper _mapper;

        public AddUserEndpoint(IRepository<User, Guid> users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Post("api/register");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddUserRequest req, CancellationToken ct)
        {
            var hashedPassword = Crypto
                .HashPassword(req.Password)
                .Truncate(Models.User.PasswordHashMaxLength);

            var user = new User(req.Id, req.EmailAddress, hashedPassword);

            await _users.AddAsync(user);

            var userDTO = _mapper.Map<UserDTO>(user);

            await SendAsync(userDTO, cancellation: ct);
        }
    }
}
