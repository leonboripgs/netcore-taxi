using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IDocumentoRepository : ICreate<Documento>, IRead<Documento>, IUpdate<Documento>, IDelete<Documento>, ISave
    { }
}