using AutoMapper;
using SocialMediaExample.DTOs;
using SocialMediaExample.Entities;

namespace SocialMediaExample.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}