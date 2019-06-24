using AutoMapper;
using DTOs;
using Models;

namespace Common.mapping
{
   public class CertificationMapping : Profile
    {
        public CertificationMapping()
        {
            CreateMap<Certificate, CertificationModel>().ReverseMap();
        }
    }
}
