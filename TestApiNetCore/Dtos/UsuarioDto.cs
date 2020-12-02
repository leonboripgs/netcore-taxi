using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Dtos
{
    public class UsuarioDto
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
        /// Imagen que será usada como avatar
        /// </summary>
        public string Imagen { get; set; }
        /// <summary>
        /// Nombre fisico de la imagen
        /// </summary>
        public string NombreImagen { get; set; }
        /// <summary>
        /// Propiedad ligada al campo telefono
        /// </summary>
        public string Telefono { get; set; }
    }
}
