using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class UsuarioCriteria : ICriteria<Usuario>
    {
        public Expression<Func<Usuario, bool>> Criteria { get; private set; }

        private UsuarioCriteria() { }
        public static UsuarioCriteria Create() => new UsuarioCriteria();
        public UsuarioCriteria ByTelefono(string telefono)
        {
            Criteria = c => c.Telefono == telefono;
            return this;
        }
        public UsuarioCriteria ByUsuario(string usuario)
        {
            Criteria = c => $"{c.Nombre} {c.ApellidoPaterno} {c.ApellidoMaterno}".Contains(usuario);
            return this;
        }
    }
}
