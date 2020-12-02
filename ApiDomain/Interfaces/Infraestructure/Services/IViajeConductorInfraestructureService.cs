using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IViajeConductorInfraestructureService : ICreate<ViajeConductor>, IRead<ViajeConductor>, IUpdate<ViajeConductor>, IDelete<ViajeConductor>
    { }
}
