using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface ICancelacionViajeDomainService : ICreate<CancelacionViaje>, IRead<CancelacionViaje>, IUpdate<CancelacionViaje>, IDelete<CancelacionViaje>
    { }
}
