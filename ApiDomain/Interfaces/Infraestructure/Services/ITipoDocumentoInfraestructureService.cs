using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface ITipoDocumentoInfraestructureService : ICreate<TipoDocumento>, IRead<TipoDocumento>, IUpdate<TipoDocumento>, IDelete<TipoDocumento>
    { }
}