using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface ITipoCuentaInfraestructureService : ICreate<TipoCuenta>, IRead<TipoCuenta>, IUpdate<TipoCuenta>, IDelete<TipoCuenta>
    { }
}