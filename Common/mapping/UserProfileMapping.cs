using AutoMapper;
using DTOs;
using Models;

namespace Common.mapping
{
   public class UserProfileMapping:Profile
    {
        public UserProfileMapping()
        {
            CreateMap<User, UserProfileModel>().ReverseMap();
        }
    }
}
