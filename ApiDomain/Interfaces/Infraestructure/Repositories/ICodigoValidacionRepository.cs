using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface ICodigoValidacionRepository : IRead<CodigoValidacion>, ICreate<CodigoValidacion>, IUpdate<CodigoValidacion>, IDelete<CodigoValidacion>, ISave
    {
    }
}
