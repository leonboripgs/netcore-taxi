using ApiDomain.Entities;
using AutoMapper;
using FaxiApiNetCore.Dtos;

namespace FaxiApiNetCore.Mappings.Profiles
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            CreateMap<Vehiculo, VehiculoDto>();
            CreateMap<VehiculoDto, Vehiculo>();
        }
    }
}
