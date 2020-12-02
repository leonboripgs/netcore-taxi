using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface ICodigoValidacionDomainService : IRead<CodigoValidacion>
    {
        void Save(CodigoValidacion codigoValidacion);
        void Delete(CodigoValidacion codigoValidacion);
        CodigoValidacion Login(CodigoValidacion codigoValidacion);
    }
}
