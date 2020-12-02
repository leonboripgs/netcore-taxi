using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface ICancelacionViajeInfraestructureService : ICreate<CancelacionViaje>, IRead<CancelacionViaje>, IUpdate<CancelacionViaje>, IDelete<CancelacionViaje>
    { }
}
