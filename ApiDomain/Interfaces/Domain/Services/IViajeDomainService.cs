using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IViajeDomainService : ICreate<Viaje>, IRead<Viaje>, IUpdate<Viaje>, IDelete<Viaje>
    { }
}
