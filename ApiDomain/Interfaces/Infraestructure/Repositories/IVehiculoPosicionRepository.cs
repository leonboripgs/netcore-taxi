using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IVehiculoPosicionRepository : ICreate<VehiculoPosicion>, IRead<VehiculoPosicion>, IUpdate<VehiculoPosicion>, IDelete<VehiculoPosicion>, ISave
    { }
}