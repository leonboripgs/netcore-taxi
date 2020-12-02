using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IUsuarioInfraestructureService : ICreate<Usuario>, IRead<Usuario>, IUpdate<Usuario>, IDelete<Usuario>
    { }
}