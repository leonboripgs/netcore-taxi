using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IViajeUsuarioRepository : ICreate<ViajeUsuario>, IRead<ViajeUsuario>, IUpdate<ViajeUsuario>, IDelete<ViajeUsuario>, ISave
    { }
}