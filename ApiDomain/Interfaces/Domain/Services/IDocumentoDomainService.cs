using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IDocumentoDomainService : ICreate<Documento>, IRead<Documento>, IUpdate<Documento>, IDelete<Documento>
    { }
}