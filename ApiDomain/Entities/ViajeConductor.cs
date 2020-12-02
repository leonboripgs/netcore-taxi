using System;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla historial_viajes_conductores
    /// </summary>
    public class ViajeConductor : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_conductor
        /// </summary>
        public int IdConductor { get; set; }
        /// <summary>
        /// Referencia a una cuenta de usuario de conductor
        /// </summary>
        public virtual CuentaUsuario Conductor { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_viaje
        /// </summary>
        public int IdViaje { get; set; }
        /// <summary>
        /// Referencia a viaje
        /// </summary>
        public virtual Viaje Viaje { get; set; }
        /// <summary>
        /// Propiedad ligada al campo km_recorridos
        /// </summary>
        public decimal KmRecorridos { get; set; }
        /// <summary>
        /// Propiedad ligada al campo tarifa
        /// </summary>
        public decimal Tarifa { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
    }
}