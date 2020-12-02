using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IVehiculoDomainService : ICreate<Vehiculo>, IRead<Vehiculo>, IUpdate<Vehiculo>, IDelete<Vehiculo>
    { }
}