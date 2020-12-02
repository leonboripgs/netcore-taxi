using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface ICancelacionViajeRepository : ICreate<CancelacionViaje>, IRead<CancelacionViaje>, IUpdate<CancelacionViaje>, IDelete<CancelacionViaje>, ISave
    { }
}
