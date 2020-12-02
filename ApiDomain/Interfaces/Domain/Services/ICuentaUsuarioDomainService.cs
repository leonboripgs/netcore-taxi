using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface ICuentaUsuarioDomainService : ICreate<CuentaUsuario>, IRead<CuentaUsuario>, IUpdate<CuentaUsuario>, IDelete<CuentaUsuario>
    { }
}