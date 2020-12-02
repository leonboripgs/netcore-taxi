using ApiDomain.Entities;
using AutoMapper;
using FaxiApiNetCore.Dtos;

namespace FaxiApiNetCore.Mappings.Profiles
{
    public class ViajeProfile : Profile
    {
        public ViajeProfile()
        {
            CreateMap<Viaje, ViajeDto>();
            CreateMap<ViajeDto, Viaje>();
        }
    }
}
