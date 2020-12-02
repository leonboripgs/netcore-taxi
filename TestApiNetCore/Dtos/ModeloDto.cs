namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla cat_modelos_vehiculos
    /// </summary>

    public class ModeloDto
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
        /// Propiedad ligada al campo id_marca
        /// </summary>
        public int IdMarca { get; set; }
    }
}