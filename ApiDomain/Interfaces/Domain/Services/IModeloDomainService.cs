using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IModeloDomainService : ICreate<Modelo>, IRead<Modelo>, IUpdate<Modelo>, IDelete<Modelo>
    { }
}