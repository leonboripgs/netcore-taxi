using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Services;

namespace ApiInfraestructure.Services
{
    public class UserService : IUserInfraestructureService
    {
        public User Login(string telefono, string password)
        {
            return new User { Telefono = telefono, Password = password };
        }
    }
}
