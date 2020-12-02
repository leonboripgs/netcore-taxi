using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IImagenDomainService : ICreate<Imagen>, IRead<Imagen>, IUpdate<Imagen>, IDelete<Imagen>
    { }
}