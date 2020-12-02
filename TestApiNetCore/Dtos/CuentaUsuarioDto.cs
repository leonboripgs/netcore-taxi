namespace FaxiApiNetCore.Dtos
{
    /// <summary>
    /// Entidad que representa la tabla cuentas_usuario
    /// </summary>
    public class CuentaUsuarioDto
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_usuario
        /// </summary>
        public UsuarioDto Usuario { get; set; }
        /// <summary>
        /// Propiedad ligada al campo password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Propiedad ligada al campo email
        /// </summary>
        public string Email { get; set; }
    }
}
