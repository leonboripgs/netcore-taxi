using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDomain.Entities
{
    public class CodigoValidacion : BaseEntity
    {
        public int? Id { get; set; }
        public string Telefono { get; set; }
        public int? Codigo { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }
}
