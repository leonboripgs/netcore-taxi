using System.Collections.Generic;

namespace ApiDomain.Entities
{
    public class Entidad : BaseEntity
    {
        public string Id { get; set; }
        public virtual Pais Pais { get; set; }
        public string ClavePais { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public virtual List<Municipio> Municipios { get; set; }
    }
}
