using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IMarcaRepository : ICreate<Marca>, IRead<Marca>, IUpdate<Marca>, IDelete<Marca>, ISave
    { }
}