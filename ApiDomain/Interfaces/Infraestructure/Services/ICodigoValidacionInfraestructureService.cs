using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface ICodigoValidacionInfraestructureService : IRead<CodigoValidacion>, ICreate<CodigoValidacion>, IUpdate<CodigoValidacion>, IDelete<CodigoValidacion>
    {
    }
}
