using System;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla vehiculos posicion(GPS Location)
    /// </summary>
    public class VehiculoPosicion : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        public int IdCuentaUsuario { get; set; }
        /// <summary>
        /// Referencia a la cuenta de usuario
        /// </summary>
        //public virtual CuentaUsuario CuentaUsuario { get; set; }
        /// <summary>
        /// Propiedad ligada al campo color
        /// </summary>
        public double Latitud { get; set; }
        /// <summary>
        /// Propiedad ligada al campo color
        /// </summary>
        public double Longitud { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime UltimaActualizacion { get; set; }
    }
}