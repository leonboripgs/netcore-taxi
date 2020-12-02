using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class CuentaUsuarioCriteria : ICriteria<CuentaUsuario>
    {
        public Expression<Func<CuentaUsuario, bool>> Criteria { get; private set; }

        private CuentaUsuarioCriteria() { }
        public static CuentaUsuarioCriteria Create() => new CuentaUsuarioCriteria();
        public CuentaUsuarioCriteria ByIdUsuario(int idUsuario)
        {
            Criteria = c => c.IdUsuario == idUsuario;
            return this;
        }
        public CuentaUsuarioCriteria ByTipoCuenta(int idTipoCuenta)
        {
            Criteria = c => c.IdTipoCuenta == idTipoCuenta;
            return this;
        }
    }
}
