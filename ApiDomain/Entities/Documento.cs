using System;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla documentos
    /// </summary>
    public class Documento : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_tipo
        /// </summary>
        public int TipoDocumentoId { get; set; }
        /// <summary>
        /// Propiedad ligada al campo referencia
        /// </summary>
        public string Referencia { get; set; }
        /// <summary>
        /// Propiedad ligada al campo vigencia
        /// </summary>
        public DateTime? Vigencia { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_cuenta
        /// </summary>
        public int? CuentaUsuarioId { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_vehiculo
        /// </summary>
        public int? VehiculoId { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_imagen
        /// </summary>
        public int? ImagenId { get; set; }        
        /// <summary>
        /// Referencia a tipo de documento
        /// </summary>
        public TipoDocumento TipoDocumento { get; set; }
        /// <summary>
        /// Referencia a imagen
        /// </summary>
        public Imagen Imagen { get; set; }
        /// <summary>
        /// Referencia a cuenta de usuario
        /// </summary>
        public CuentaUsuario CuentaUsuario { get; set; }
    }
}
