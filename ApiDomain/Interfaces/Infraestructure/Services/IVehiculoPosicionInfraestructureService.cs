using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IVehiculoPosicionInfraestructureService : ICreate<VehiculoPosicion>, IRead<VehiculoPosicion>, IUpdate<VehiculoPosicion>, IDelete<VehiculoPosicion>
    { }
}
