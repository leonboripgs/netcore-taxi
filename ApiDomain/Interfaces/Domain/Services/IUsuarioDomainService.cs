using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IUsuarioDomainService : ICreate<Usuario>, IRead<Usuario>, IUpdate<Usuario>, IDelete<Usuario>
    { }
}