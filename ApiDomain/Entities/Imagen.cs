using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla imagenes
    /// </summary>
    public class Imagen : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo image
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime? UltimaModificacion { get; set; }
        /// <summary>
        /// Nombre fisico de la imagen
        /// </summary>
        public string NombreImagen { get; set; }
        /// <summary>
        /// Usuarios relacionados con la imagen
        /// </summary>
        public virtual List<Usuario> Usuarios { get; set; }
        /// <summary>
        /// Documentos relacionados con la imagen
        /// </summary>
        public virtual List<Documento> Documentos { get; set; }
    }
}