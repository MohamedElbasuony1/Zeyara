using AutoMapper;
using DTOs;
using Models;

namespace Common.mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role.Role_Name))
                .ReverseMap();
        }
    }
}
