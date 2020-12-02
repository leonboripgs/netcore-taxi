using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla cat_modelos_vehiculos
    /// </summary>
    public class Modelo : BaseEntity
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
        /// Propiedad ligada al campo id_marca
        /// </summary>
        public int IdMarca { get; set; }
        /// <summary>
        /// Referencia a marca
        /// </summary>
        public virtual Marca Marca { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime UltimaModificacion { get; set; }
        /// <summary>
        /// Coleccion de vehiculos
        /// </summary>
        public virtual List<Vehiculo> Vehiculos { get; set; }
    }
}