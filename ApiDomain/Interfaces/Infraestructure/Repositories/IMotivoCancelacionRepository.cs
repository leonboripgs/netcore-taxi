using ApiDomain.Entities;
using ApiDomain.Shared.Data;

namespace ApiDomain.Interfaces.Infraestructure.Repositories
{
    public interface IMotivoCancelacionRepository : ICreate<MotivoCancelacion>, IRead<MotivoCancelacion>, IUpdate<MotivoCancelacion>, IDelete<MotivoCancelacion>, ISave
    { }
}
