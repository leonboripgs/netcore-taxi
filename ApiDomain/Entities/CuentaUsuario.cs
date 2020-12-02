using System;
using System.Collections.Generic;

namespace ApiDomain.Entities
{
    /// <summary>
    /// Entidad que representa la tabla cuentas_usuario
    /// </summary>
    public class CuentaUsuario : BaseEntity
    {
        /// <summary>
        /// Propiedad ligada al campo id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_usuario
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Usuario al que se liga la cuenta
        /// </summary>
        public virtual Usuario Usuario { get; set; }
        /// <summary>
        /// Propiedad ligada al campo password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Propiedad ligada al campo email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Propiedad ligada al campo id_tipo_cuenta
        /// </summary>
        public int IdTipoCuenta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo domicilio
        /// </summary>
        public string Domicilio { get; set; }

        public bool EnServicio { get; set; }
        /// <summary>
        /// Tipo de cuenta
        /// </summary>
        public virtual TipoCuenta TipoCuenta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo fecha_alta
        /// </summary>
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Propiedad ligada al campo ultima_modificacion
        /// </summary>
        public DateTime? UltimaModificacion { get; set; }
        public virtual List<Documento> Documentos { get; set; }
        public virtual List<Vehiculo> Vehiculos { get; set; }
        public virtual List<CancelacionViaje> CancelacionesViajes { get; set; }
        public virtual List<ViajeConductor> ViajesConductor { get; set; }
        public virtual List<ViajeUsuario> ViajesCliente { get; set; }
    }
}