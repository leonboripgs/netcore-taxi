using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface ITipoCuentaRepository : ICreate<TipoCuenta>, IRead<TipoCuenta>, IUpdate<TipoCuenta>, IDelete<TipoCuenta>, ISave
    { }
}