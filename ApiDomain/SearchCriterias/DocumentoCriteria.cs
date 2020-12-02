using ApiDomain.Entities;
using ApiDomain.Shared.Data;
using System;
using System.Linq.Expressions;

namespace ApiDomain.SearchCriterias
{
    public class DocumentoCriteria : ICriteria<Documento>
    {
        public Expression<Func<Documento, bool>> Criteria { get; private set; }

        private DocumentoCriteria() { }
        public static DocumentoCriteria Create() => new DocumentoCriteria();
        public DocumentoCriteria ByTipoAndCuenta(int cuentaUsuarioId, int tipoDocumentoId)
        {
            Criteria = c => c.TipoDocumentoId == tipoDocumentoId && c.CuentaUsuarioId == cuentaUsuarioId;
            return this;
        }
        public DocumentoCriteria ByTipoAndVehiculo(int vehiculoId, int tipoDocumentoId)
        {
            Criteria = c => c.TipoDocumentoId == tipoDocumentoId && c.VehiculoId == vehiculoId;
            return this;
        }
    }
}
