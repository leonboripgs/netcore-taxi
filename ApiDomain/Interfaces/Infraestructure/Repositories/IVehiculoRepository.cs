using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IVehiculoRepository : ICreate<Vehiculo>, IRead<Vehiculo>, IUpdate<Vehiculo>, IDelete<Vehiculo>, ISave
    { }
}