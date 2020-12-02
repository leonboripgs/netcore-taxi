using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IModeloInfraestructureService : ICreate<Modelo>, IRead<Modelo>, IUpdate<Modelo>, IDelete<Modelo>
    { }
}