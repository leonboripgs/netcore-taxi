using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IImagenInfraestructureService : ICreate<Imagen>, IRead<Imagen>, IUpdate<Imagen>, IDelete<Imagen>
    { }
}