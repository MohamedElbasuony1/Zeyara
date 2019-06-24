using AutoMapper;
using DTOs;
using Models;

namespace Common.mapping
{
    public class PhoneMapping:Profile
    {
        public PhoneMapping()
        {
            CreateMap<Phone, PhoneModel>().ReverseMap();
        }
    }
}
