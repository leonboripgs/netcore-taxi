using AutoMapper;
using FaxiApiNetCore.Mappings.Profiles;

namespace FaxiApiNetCore.Mappings
{
    public class AutoMapperConfiguration
    {
        public static IMapper RegisterMappings()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CuentaUsuarioProfile());          });

            return mapperConfig.CreateMapper();
        }
    }
}
