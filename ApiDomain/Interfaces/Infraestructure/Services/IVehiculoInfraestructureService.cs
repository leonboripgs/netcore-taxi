using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IVehiculoInfraestructureService : ICreate<Vehiculo>, IRead<Vehiculo>, IUpdate<Vehiculo>, IDelete<Vehiculo>
    { }
}
