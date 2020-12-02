using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Dtos
{
    public class ViajeDto
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
        /// Propiedad ligada al campo hora_inicio
        /// </summary>
        public TimeSpan? HoraInicio { get; set; }
        /// <summary>
        /// Propiedad ligada al campo hora_fin
        /// </summary>
        public TimeSpan? HoraFin { get; set; }
    }
}
