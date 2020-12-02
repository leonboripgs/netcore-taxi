using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IViajeRepository : ICreate<Viaje>, IRead<Viaje>, IUpdate<Viaje>, IDelete<Viaje>, ISave
    { }
}
