using ApiDomain.Entities;
using AutoMapper;
using FaxiApiNetCore.Dtos;

namespace FaxiApiNetCore.Mappings.Profiles
{
    public class EstatusViajeProfile : Profile
    {
        public EstatusViajeProfile()
        {
            CreateMap<EstatusViaje, EstatusViajeDto>();
            CreateMap<EstatusViajeDto, EstatusViaje>();
        }
    }
}
