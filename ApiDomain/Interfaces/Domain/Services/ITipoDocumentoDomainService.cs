using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface ITipoDocumentoDomainService : ICreate<TipoDocumento>, IRead<TipoDocumento>, IUpdate<TipoDocumento>, IDelete<TipoDocumento>
    { }
}