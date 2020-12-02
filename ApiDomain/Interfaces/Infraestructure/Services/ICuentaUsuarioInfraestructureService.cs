using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface ICuentaUsuarioInfraestructureService : ICreate<CuentaUsuario>, IRead<CuentaUsuario>, IUpdate<CuentaUsuario>, IDelete<CuentaUsuario>
    { }
}