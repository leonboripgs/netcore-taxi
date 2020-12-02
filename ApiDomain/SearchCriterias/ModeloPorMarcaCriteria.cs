using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class ModeloPorMarcaCriteria : ICriteria<Modelo>
    {
        public Expression<Func<Modelo, bool>> Criteria { get; private set; }

        public ModeloPorMarcaCriteria(int marcaId)
        {
            if (marcaId <= 0)
                throw new CriteriaException("No se ha proporcionado una ID de marca");

            this.Criteria = c => c.IdMarca == marcaId;
        }
    }
}
