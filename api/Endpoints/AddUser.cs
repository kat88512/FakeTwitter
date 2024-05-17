using api.Interfaces;
using api.Models;
using api.RequestModels;
using api.ResponseModels;
using CryptoHelper;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;

namespace api.Endpoints
{
    public class AddUser : Endpoint<AddUserRequest, UserDTO>
    {
        private readonly IRepository<User, Guid> _users;
        private readonly IMapper _mapper;

        public AddUser(IRepository<User, Guid> users, IMapper mapper)
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
            var hashedPassword = Crypto.HashPassword(req.Password);

            var user = new User(req.Id, req.EmailAddress, hashedPassword);

            await _users.AddAsync(user);

            var userDTO = _mapper.Map<UserDTO>(user);

            await SendAsync(userDTO, cancellation: ct);
        }
    }
}
