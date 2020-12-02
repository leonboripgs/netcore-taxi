using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IEstatusViajeDomainService : ICreate<EstatusViaje>, IRead<EstatusViaje>, IUpdate<EstatusViaje>, IDelete<EstatusViaje>
    { }
}
