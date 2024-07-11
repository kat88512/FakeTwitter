using api.Features.Posts;
using api.Features.Users;
using api.Models;
using AutoMapper;

namespace api.Configuration.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
