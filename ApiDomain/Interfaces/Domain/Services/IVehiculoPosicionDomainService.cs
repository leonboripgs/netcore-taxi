using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IVehiculoPosicionDomainService : ICreate<VehiculoPosicion>, IRead<VehiculoPosicion>, IUpdate<VehiculoPosicion>, IDelete<VehiculoPosicion>
    { }
}