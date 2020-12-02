using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class EstatusViajeCriteria : ICriteria<EstatusViaje>
    {
        public Expression<Func<EstatusViaje, bool>> Criteria { get; private set; }

        private EstatusViajeCriteria() { }
        public static EstatusViajeCriteria Create() => new EstatusViajeCriteria();
        public EstatusViajeCriteria ByNombre(string nombreStatus)
        {
            nombreStatus = nombreStatus.Trim();
            Criteria = c => c.Nombre.ToLower().Equals(nombreStatus.ToString());
            return this;
        }
    }
}
