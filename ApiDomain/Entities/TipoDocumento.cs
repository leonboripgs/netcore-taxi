using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla cat_tipos_documento
    /// </summary>
    public class TipoDocumento : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo nombre_documento
        /// </summary>
        public string NombreDocumento { get; set; }
        /// <summary>
        /// Documentos ligados
        /// </summary>
        public virtual List<Documento> Documentos { get; set; }
    }
}