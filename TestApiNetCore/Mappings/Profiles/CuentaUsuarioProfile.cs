using ApiDomain.Entities;
using AutoMapper;
using FaxiApiNetCore.Dtos;

namespace FaxiApiNetCore.Mappings.Profiles
{
    public class CuentaUsuarioProfile : Profile
    {
        public CuentaUsuarioProfile()
        {
            CreateMap<CuentaUsuario, CuentaUsuarioDto>();
            CreateMap<CuentaUsuarioDto, CuentaUsuario>();
        }
    }
}
