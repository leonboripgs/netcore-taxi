using ApiDomain.Entities;
using AutoMapper;
using FaxiApiNetCore.Dtos;

namespace FaxiApiNetCore.Mappings.Profiles
{
    public class ModeloProfile : Profile
    {
        public ModeloProfile()
        {
            CreateMap<Modelo, ModeloDto>();
            CreateMap<ModeloDto, Modelo>();
        }
    }
}
