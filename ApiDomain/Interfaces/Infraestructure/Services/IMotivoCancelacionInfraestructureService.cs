using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Services
{
    public interface IMotivoCancelacionInfraestructureService : ICreate<MotivoCancelacion>, IRead<MotivoCancelacion>, IUpdate<MotivoCancelacion>, IDelete<MotivoCancelacion>
    { }
}
