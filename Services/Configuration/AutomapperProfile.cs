using AutoMapper;
using Contracts.Follows;
using Contracts.Posts;
using Contracts.Users;
using Domain.Follows;
using Domain.Posts;
using Domain.Users;

namespace Services.Configuration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Follow, FollowDTO>();
        }
    }
}
