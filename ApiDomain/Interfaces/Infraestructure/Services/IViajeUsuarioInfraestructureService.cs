using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IViajeUsuarioInfraestructureService : ICreate<ViajeUsuario>, IRead<ViajeUsuario>, IUpdate<ViajeUsuario>, IDelete<ViajeUsuario>
    { }
}
