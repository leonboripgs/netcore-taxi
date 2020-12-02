using System;

namespace FaxiApiNetCore.Dtos
{
    public class DocumentoConductorDto
    {
        public int? Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Referencia { get; set; }
        public DateTime? Vigencia { get; set; }
    }
}
