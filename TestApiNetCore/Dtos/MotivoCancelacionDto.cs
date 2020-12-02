namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla cat_motivos_cancelacion
    /// </summary>
    public class MotivoCancelacionDto
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo motivo
        /// </summary>
        public string Motivo { get; set; }
    }
}
