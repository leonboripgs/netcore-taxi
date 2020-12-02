using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IViajeUsuarioDomainService : ICreate<ViajeUsuario>, IRead<ViajeUsuario>, IUpdate<ViajeUsuario>, IDelete<ViajeUsuario>
    { }
}
