using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// entidad que representa un pais
    /// </summary>
    public class Pais : BaseEntity
    {
        /// <summary>
        /// Identificador único
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nombre del país
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Colección de entidades del pais
        /// </summary>
        public virtual List<Entidad> Entidades { get; set; }
    }
}
