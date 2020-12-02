using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface ITipoCuentaDomainService : ICreate<TipoCuenta>, IRead<TipoCuenta>, IUpdate<TipoCuenta>, IDelete<TipoCuenta>
    { }
}