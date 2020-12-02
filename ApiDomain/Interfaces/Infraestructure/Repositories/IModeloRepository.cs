using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IModeloRepository : ICreate<Modelo>, IRead<Modelo>, IUpdate<Modelo>, IDelete<Modelo>, ISave
    { }
}