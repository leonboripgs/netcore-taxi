using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IEstatusViajeInfraestructureService : ICreate<EstatusViaje>, IRead<EstatusViaje>, IUpdate<EstatusViaje>, IDelete<EstatusViaje>
    { }
}
