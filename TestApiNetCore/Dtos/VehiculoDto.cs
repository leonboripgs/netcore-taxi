using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla vehiculos
    /// </summary>
    public class VehiculoDto
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_modelo
        /// </summary>
        public int IdModelo { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_cuenta_usuario
        /// </summary>
        public int IdCuentaUsuario { get; set; }
        /// <summary>
        /// Propiedad ligada al campo anio
        /// </summary>
        public int Anio { get; set; }
        /// <summary>
        /// Propiedad ligada al campo color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Propiedad ligada al campo placa
        /// </summary>
        public string Placa { get; set; }
    }
}
