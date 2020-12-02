namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla cat_marcas_vehiculos
    /// </summary>

    public class MarcaDto
    {

        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo nombre
        /// </summary>
        public string Nombre { get; set; }
    }
}