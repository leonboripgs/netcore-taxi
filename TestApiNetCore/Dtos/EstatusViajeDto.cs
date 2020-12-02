using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla cat_estatus_viajes
    /// </summary>
    public class EstatusViajeDto
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Propiedad ligada al campo descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}
