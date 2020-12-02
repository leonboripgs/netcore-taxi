using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IViajeInfraestructureService : ICreate<Viaje>, IRead<Viaje>, IUpdate<Viaje>, IDelete<Viaje>
    { }
}
