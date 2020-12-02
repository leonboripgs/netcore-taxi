using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla vehiculos
    /// </summary>
    public class VehiculoPosicionDto
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
        /// Propiedad ligada al campo color
        /// </summary>
        public double Latitud { get; set; }
        /// <summary>
        /// Propiedad ligada al campo placa
        /// </summary>
        public double Longitud { get; set; }
    }
}
