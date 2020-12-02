using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface ITipoDocumentoRepository : ICreate<TipoDocumento>, IRead<TipoDocumento>, IUpdate<TipoDocumento>, IDelete<TipoDocumento>, ISave
    { }
}