using Api.Features.Follows;
using Api.Features.Posts;
using Api.Features.Users;
using Api.Models;
using AutoMapper;

namespace Api.Configuration.Automapper
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
