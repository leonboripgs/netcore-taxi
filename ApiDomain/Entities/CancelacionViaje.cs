using System;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla cancelaciones_viajes
    /// </summary>
    public class CancelacionViaje : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_cuenta_usuario
        /// </summary>
        public int IdCuentaUsuario { get; set; }
        /// <summary>
        /// Referencia a cuenta de usuario
        /// </summary>
        public virtual CuentaUsuario CuentaUsuario { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_motivo_cancelacion
        /// </summary>
        public int IdMotivoCancelacion { get; set; }
        /// <summary>
        /// Referencia a motivo de cancelacion
        /// </summary>
        public virtual MotivoCancelacion MotivoCancelacion { get; set; }
        /// <summary>
        /// Propiedad ligada al campo observaciones
        /// </summary>
        public string Observaciones { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_viaje
        /// </summary>
        public int IdViaje { get; set; }
        /// <summary>
        /// Referencia a viaje
        /// </summary>
        public virtual Viaje Viaje { get; set; }
    }
}