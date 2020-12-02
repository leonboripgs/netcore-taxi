using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IUsuarioRepository : ICreate<Usuario>, IRead<Usuario>, IUpdate<Usuario>, IDelete<Usuario>, ISave
    { }
}