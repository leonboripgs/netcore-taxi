using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface ICuentaUsuarioRepository : ICreate<CuentaUsuario>, IRead<CuentaUsuario>, IUpdate<CuentaUsuario>, IDelete<CuentaUsuario>, ISave
    { }
}