using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IMarcaDomainService : ICreate<Marca>, IRead<Marca>, IUpdate<Marca>, IDelete<Marca>
    { }
}