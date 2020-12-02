using System;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla vehiculos
    /// </summary>
    public class Vehiculo : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_modelo
        /// </summary>
        public int IdModelo { get; set; }
        /// <summary>
        /// Referencia al modelo
        /// </summary>
        public virtual Modelo Modelo { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_cuenta_usuario
        /// </summary>
        public int IdCuentaUsuario { get; set; }
        /// <summary>
        /// Referencia a la cuenta de usuario
        /// </summary>
        public virtual CuentaUsuario CuentaUsuario { get; set; }
        /// <summary>
        /// Propiedad ligada al campo anio
        /// </summary>
        public int Anio { get; set; }
        /// <summary>
        /// Propiedad ligada al campo color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Propiedad ligada al campo placa
        /// </summary>
        public string Placa { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime UltimaModificacion { get; set; }
    }
}