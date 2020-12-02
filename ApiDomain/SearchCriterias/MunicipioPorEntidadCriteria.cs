using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class MunicipioPorEntidadCriteria : ICriteria<Municipio>
    {
        public Expression<Func<Municipio, bool>> Criteria { get; private set; }

        public MunicipioPorEntidadCriteria(string entidadId)
        {
            if (string.IsNullOrWhiteSpace(entidadId))
                throw new CriteriaException("No se ha proporcionado una ID de entidad");

            this.Criteria = c => c.EntidadId == entidadId;
        }
    }
}
