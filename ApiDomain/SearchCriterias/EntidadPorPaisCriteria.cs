using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class EntidadPorPaisCriteria : ICriteria<Entidad>
    {
        public Expression<Func<Entidad, bool>> Criteria { get; private set; }

        public EntidadPorPaisCriteria(string paisId)
        {
            if (string.IsNullOrWhiteSpace(paisId))
                throw new CriteriaException("No se ha proporcionado una ID de pais");

            this.Criteria = c => c.ClavePais == paisId;
        }
    }
}
