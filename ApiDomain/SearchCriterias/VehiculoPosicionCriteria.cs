using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class VehiculoPosicionCriteria : ICriteria<VehiculoPosicion>
    {
        public Expression<Func<VehiculoPosicion, bool>> Criteria { get; private set; }

        private VehiculoPosicionCriteria() { }
        public static VehiculoPosicionCriteria Create() => new VehiculoPosicionCriteria();
        public VehiculoPosicionCriteria ById(int id)
        {
            Criteria = c => c.Id == id;
            return this;
        }
    }
}
