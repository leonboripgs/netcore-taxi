using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IDocumentoInfraestructureService : ICreate<Documento>, IRead<Documento>, IUpdate<Documento>, IDelete<Documento>
    { }
}