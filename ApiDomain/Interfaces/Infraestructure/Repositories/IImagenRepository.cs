using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IImagenRepository : ICreate<Imagen>, IRead<Imagen>, IUpdate<Imagen>, IDelete<Imagen>, ISave
    { }
}