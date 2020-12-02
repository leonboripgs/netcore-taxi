using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class ClaveMunicipioCriteria : ICriteria<Municipio>
    {
        public Expression<Func<Municipio, bool>> Criteria { get; private set; }

        public ClaveMunicipioCriteria(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                throw new CriteriaException("No se ha proporcionado una ID de municipio");

            this.Criteria = c => c.Id == clave;
        }
    }
}
