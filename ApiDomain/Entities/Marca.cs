using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla cat_marcas_vehiculos
    /// </summary>
    public class Marca : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime? UltimaModificacion { get; set; }
        /// <summary>
        /// Colección de modelos
        /// </summary>
        public virtual List<Modelo> Modelos { get; set; }
    }
}
