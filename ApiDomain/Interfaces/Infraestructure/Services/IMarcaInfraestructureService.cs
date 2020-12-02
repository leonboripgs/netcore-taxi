using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IMarcaInfraestructureService : ICreate<Marca>, IRead<Marca>, IUpdate<Marca>, IDelete<Marca>
    { }
}