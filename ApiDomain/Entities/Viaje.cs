using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla viajes
    /// </summary>
    public class Viaje : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo latitud_origen
        /// </summary>
        public string LatitudOrigen { get; set; }
        /// <summary>
        /// Propiedad ligada al campo longitud_origen
        /// </summary>
        public string LongitudOrigen { get; set; }
        /// <summary>
        /// Propiedad ligada al campo latitud_destino
        /// </summary>
        public string LatitudDestino { get; set; }
        /// <summary>
        /// Propiedad ligada al campo longitud_destino
        /// </summary>
        public string LongitudDestino { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_estatus_viaje
        /// </summary>
        public int EstatusViajeId { get; set; }
        /// <summary>
        /// Propiedad ligada al campo hora_inicio
        /// </summary>
        public TimeSpan? HoraInicio { get; set; }
        /// <summary>
        /// Propiedad ligada al campo hora_fin
        /// </summary>
        public TimeSpan? HoraFin { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime? UltimaModificacion { get; set; }
        /// <summary>
        /// Referencias a viajes de usuario
        /// </summary>
        public virtual List<ViajeUsuario> ViajesCliente { get; set; }
        /// <summary>
        /// Referencias a viajes de conductor
        /// </summary>
        public virtual List<ViajeConductor> ViajesConductor { get; set; }
        /// <summary>
        /// Referencias a cancelaciones de viaje
        /// </summary>
        public virtual List<CancelacionViaje> CancelacionesViaje { get; set; }
        /// <summary>
        /// Referencia a un estatus de viaje
        /// </summary>
        public virtual EstatusViaje EstatusViaje { get; set; }
    }
}