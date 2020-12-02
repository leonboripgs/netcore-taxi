using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Domain.Services
{
    public interface IMotivoCancelacionDomainService : ICreate<MotivoCancelacion>, IRead<MotivoCancelacion>, IUpdate<MotivoCancelacion>, IDelete<MotivoCancelacion>
    { }
}
