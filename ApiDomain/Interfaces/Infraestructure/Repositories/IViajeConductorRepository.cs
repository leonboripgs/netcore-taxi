using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IViajeConductorRepository : ICreate<ViajeConductor>, IRead<ViajeConductor>, IUpdate<ViajeConductor>, IDelete<ViajeConductor>, ISave
    { }
}
