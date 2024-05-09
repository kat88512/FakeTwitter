using api.Models;
using api.ResponseModels;
using AutoMapper;

namespace api.Config
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDTO>();
        }
    }
}
