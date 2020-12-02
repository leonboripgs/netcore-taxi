using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
public interface IEstatusViajeRepository : ICreate<EstatusViaje>, IRead<EstatusViaje>, IUpdate<EstatusViaje>, IDelete<EstatusViaje>, ISave
{ }
}
