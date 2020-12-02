using ApiDomain.Entities;
using AutoMapper;
using FaxiApiNetCore.Dtos;

namespace FaxiApiNetCore.Mappings.Profiles
{
    public class MotivoCancelacionProfile : Profile
    {
        public MotivoCancelacionProfile()
        {
            CreateMap<MotivoCancelacion, MotivoCancelacionDto>();
            CreateMap<MotivoCancelacionDto, MotivoCancelacion>();
        }
    }
}
