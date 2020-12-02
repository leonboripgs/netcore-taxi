using System;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla historial_viajes_usuarios
    /// </summary>
    public class ViajeUsuario : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_cliente
        /// </summary>
        public int ClienteId { get; set; }
        /// <summary>
        /// Referencia a una cuenta de usuario de cliente
        /// </summary>
        public virtual CuentaUsuario Cliente { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_viaje
        /// </summary>
        public int ViajeId { get; set; }
        /// <summary>
        /// Referencia a viaje
        /// </summary>
        public virtual Viaje Viaje { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
    }
}