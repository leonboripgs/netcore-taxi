using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class TipoCuentaCriteria : ICriteria<TipoCuenta>
    {
        public Expression<Func<TipoCuenta, bool>> Criteria { get; private set; }

        private TipoCuentaCriteria() { }
        public static TipoCuentaCriteria Create() => new TipoCuentaCriteria();
        public TipoCuentaCriteria LikeNombre(string nombre)
        {
            Criteria = c => c.Nombre.Contains(nombre);
            return this;
        }
        public TipoCuentaCriteria EqualNombre(string nombre)
        {
            Criteria = c => string.Equals(c.Nombre, nombre, StringComparison.InvariantCultureIgnoreCase);
            return this;
        }
    }
}
