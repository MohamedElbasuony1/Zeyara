using AutoMapper;
using DTOs;
using Models;

namespace Common.mapping
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}
