using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class VehiculoPorConductorCriteria : ICriteria<Vehiculo>
    {
        public Expression<Func<Vehiculo, bool>> Criteria { get; private set; }

        public VehiculoPorConductorCriteria(int conductorId)
        {
            if (conductorId <= 0)
                throw new CriteriaException("No se ha proporcionado una ID de conductor");

            this.Criteria = c => c.IdCuentaUsuario == conductorId;
        }
    }
}
