using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class CodigoValidacionCriteria : ICriteria<CodigoValidacion>
    {
        public Expression<Func<CodigoValidacion, bool>> Criteria { get; private set; }

        public CodigoValidacionCriteria(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new CriteriaException("No se ha proporcionado u número de teléfono");

            this.Criteria = c => c.Telefono == telefono;
        }
        public CodigoValidacionCriteria(string telefono, int? codigo)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new CriteriaException("No se ha proporcionado un número de teléfono");

            if (!codigo.HasValue)
                throw new CriteriaException("No se ha proporcionado un código de verificación");

            this.Criteria = c => c.Telefono == telefono && c.Codigo == codigo && c.FechaGeneracion.Date == DateTime.Now.Date;
        }
        public CodigoValidacionCriteria(DateTime fechaGeneracion)
        {
            this.Criteria = c => c.FechaGeneracion.Date != fechaGeneracion.Date;
        }
    }
}
