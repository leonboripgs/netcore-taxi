using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla usuarios
    /// </summary>
    public class Usuario : BaseEntity
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
        /// Propiedad ligada al campo apellido_paterno
        /// </summary>
        public string ApellidoPaterno { get; set; }
        /// <summary>
        /// Propiedad ligada al campo apellido_materno
        /// </summary>
        public string ApellidoMaterno { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_nacimiento
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_municipio
        /// </summary>
        public string IdMunicipio { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_entidad
        /// </summary>
        public string IdEntidad { get; set; }
        /// <summary>
        /// Municipio al cuál pertenece el usuario
        /// </summary>
        public virtual Municipio Municipio { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_image
        /// </summary>
        public int? ImagenId { get; set; }
        /// <summary>
        /// Imagen que será usada como avatar
        /// </summary>
        public virtual Imagen Imagen { get; set; }
        /// <summary>
        /// Propiedad ligada al campo telefono
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime? UltimaModificacion { get; set; }
        /// <summary>
        /// Cuentas de usuario ligadas al usuario específico
        /// </summary>
        public virtual List<CuentaUsuario> Cuentas { get; set; }
    }
}