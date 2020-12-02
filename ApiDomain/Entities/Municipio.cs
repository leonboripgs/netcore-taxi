using System;

namespace ApiDomain.Entities
{
    public class Municipio : BaseEntity
    {
        public string Id { get; set; }
        public string EntidadId { get; set; }
        public virtual Entidad Entidad { get; set; }
        public string Nombre { get; set; }
    }
}
