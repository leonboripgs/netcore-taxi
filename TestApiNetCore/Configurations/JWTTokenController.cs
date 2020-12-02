using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.SearchCriterias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using FaxiApiNetCore.Dtos;
using FaxiApiNetCore.Helpers;

namespace FaxiApiNetCore.Configurations
{
    /// <summary>
    /// Controlador de autenticación
    /// </summary>
    [Route("api/login")]
    [ApiController]
    [Authorize]
    public class JWTTokenController : Controller
    {
        #region Attributes

        /// <summary>
        /// Servicio de autenticación
        /// </summary>
        private readonly IUsuarioDomainService _service;
        private readonly ICodigoValidacionDomainService _codigoService;
        private readonly ICuentaUsuarioDomainService _cuentaService;
        private readonly ITipoCuentaDomainService _tipoCuentaService;
        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="service">Servicio de autenticación</param>
        public JWTTokenController(IUsuarioDomainService service, ICodigoValidacionDomainService codigoService, ICuentaUsuarioDomainService cuentaService,  ITipoCuentaDomainService tipoCuentaService)
        {
            _service = service;
            _codigoService = codigoService;
            _cuentaService = cuentaService;
            _tipoCuentaService = tipoCuentaService;
        }

        #endregion

        #region Methods        
        /// <summary>
        /// Responde a una prueba de autenticación
        /// </summary>
        /// <returns>HttpCode 200 (Ok) si el token de autenticación es válido</returns>
        [HttpGet("checkValid")]
        public ActionResult Check()     
        {
            return Ok();
        }

        /// <summary>
        /// Realiza una autenticación por medio de un número telefónico y una contraseña que ha sido previamente seleccionada por el usuario durante su registro
        /// </summary>
        /// <param name="machineName">Nombre del equipo que se va a autenticar</param>
        /// <returns>El DTO usuario con el token de autenticación asignado</returns>
        [HttpPost("Authenticate")]        
        [AllowAnonymous]
        public ActionResult Authenticate(SimpleLoginDto login)
        {
            try
            {
                var tipoCuenta = _tipoCuentaService.GetByCriteria(TipoCuentaCriteria.Create().EqualNombre(login.TipoCuenta));
                var user = _service.GetByCriteria(UsuarioCriteria.Create().ByTelefono(login.Telefono));
                var cuentas = _cuentaService.GetCollectionByCriteria(CuentaUsuarioCriteria.Create().ByIdUsuario(user.Id.Value));

                if (!cuentas.Any(item => item.IdTipoCuenta == tipoCuenta.Id && item.Password == StringHelper.GetSHA1(login.Password)))
                    return Unauthorized();

                var token = JWTTokenGenerator.GenerateToken(login.Telefono);
                if (string.IsNullOrWhiteSpace(token))
                {
                    var error = new ValidationProblemDetails
                    {
                        Title = "Error de autenticación",
                        Detail = "No se ha podido generar el token de autorización."
                    };
                    return ValidationProblem(error);
                }

                return Ok(new { token });
            }catch
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Realiza una autenticación por medio de un número telefónico y un código de seguridad 
        /// </summary>
        /// <param name="login">Objeto que contiene los elementos para auteticacion</param>
        /// <returns>Token de autenticación</returns>
        [HttpPost("CodeAuthenticate")]
        [AllowAnonymous]
        public ActionResult CodeAuthenticate(SimpleLoginDto login)
        {            
            try
            {
                var loginCode = new CodigoValidacion {
                    Telefono = login.Telefono,
                    Codigo = login.Codigo
                };
                var authenticatedUser = _codigoService.Login(loginCode);
                if(authenticatedUser == null)
                    return Unauthorized();

                var token = JWTTokenGenerator.GenerateToken(authenticatedUser.Telefono);
                if (string.IsNullOrWhiteSpace(token))
                {
                    var error = new ValidationProblemDetails
                    {
                        Title = "Error de autenticación",
                        Detail = "No se ha podido generar el token de autorización."
                    };
                    return ValidationProblem(error);
                }

                return Ok(new { token });
            }catch
            {
                return NoContent();
            }   
        }
        /// <summary>
        /// Genera un código de seguridad de cuatro dígitos y envía un SMS al número telefónico recibido en la petición
        /// </summary>
        /// <param name="login">Objeto que contiene el número telefónico al cual se enviará el código por SMS</param>
        /// <returns>StatusCode 200</returns>
        [HttpPost("GenerateCode")]
        [AllowAnonymous]
        public ActionResult GenerateCode(SimpleLoginDto login)
        {
            try
            {
                var random = new Random();
                var code = random.Next(1000, 9999);

                //var client = new CalixtaSoapWebService.GatewayPortTypeClient();
                //var tarea = client.EnviaMensajeAsync(47622, "pixitcorp@gmail.com", "d7e143c2dc5db8f9a4796595f81fd23f1f63a5a60b2f7a558c5b516a44c8087a", 
                //                                "SMS", DateTime.Now.ToString("dd/MM/YYYY/hh/mm"), login.Telefono, $"Codigo de seguridad: {code}", 0);
                //tarea.Wait();

                //if(tarea.Result == 3)
                _codigoService.Save(new CodigoValidacion { Telefono = login.Telefono, Codigo = code, FechaGeneracion = DateTime.Now });
                return Ok(new { code });

                //return BadRequest("No se ha podido enviar el SMS con codigo de seguridad, por favor contacte con el administrador.");
            }
            catch (AggregateException aex)
            {
                return ValidationProblem(new ValidationProblemDetails { Detail = aex.Message });
            }
            catch (Exception ex)
            {
                return ValidationProblem(new ValidationProblemDetails { Detail = ex.Message });
            }
        }
        #endregion
    }
}
