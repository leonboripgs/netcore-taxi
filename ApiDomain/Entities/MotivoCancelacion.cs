using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla cat_motivos_cancelacion
    /// </summary>
    public class MotivoCancelacion : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo motivo
        /// </summary>
        public string Motivo { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_tipo_cuenta
        /// </summary>
        public int IdTipoCuenta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime? UltimaModificacion { get; set; }
        /// <summary>
        /// Referencias a cancelaciones de viaje
        /// </summary>
        public virtual List<CancelacionViaje> CancelacionesViajes { get; set; }
        /// <summary>
        /// Relacion con tipo cuenta
        /// </summary>
        public virtual TipoCuenta TipoCuenta { get; set; }
    }
}