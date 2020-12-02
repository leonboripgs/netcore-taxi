using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IViajeConductorDomainService : ICreate<ViajeConductor>, IRead<ViajeConductor>, IUpdate<ViajeConductor>, IDelete<ViajeConductor>
    { }
}
