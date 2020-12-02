using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla tipos_cuenta
    /// </summary>
    public class TipoCuenta : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Propiedad ligada al campo descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_actualizacion
        /// </summary>
        public DateTime? UltimaActualizacion { get; set; }
        /// <summary>
        /// Cuentas de usuario relacionadas al tipo de cuenta
        /// </summary>
        public virtual List<CuentaUsuario> CuentasUsuario { get; set; }
        /// <summary>
        /// Relaciones con motivos de cancelacion
        /// </summary>
        public virtual List<MotivoCancelacion> MotivosCancelacion { get; set; }
    }
}
