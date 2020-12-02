using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Linq;
using FaxiApiNetCore.Dtos;
using FaxiApiNetCore.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IUsuarioDomainService _usuarioService;
        private readonly ICuentaUsuarioDomainService _cuentaUsuarioService;
        private readonly ITipoCuentaDomainService _tipoCuentaService;
        private readonly IMapper _mapper;
        #endregion
        #region CONSTRUCTOR
        public ClienteController(ICuentaUsuarioDomainService cuentaUsuarioService, IUsuarioDomainService usuarioService, ITipoCuentaDomainService tipoCuentaService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _cuentaUsuarioService = cuentaUsuarioService;
            _tipoCuentaService = tipoCuentaService;
            _mapper = mapper;
        }
        #endregion
        #region METHODS
        [HttpGet("telefono/{numero}")]
        [AllowAnonymous]
        public IActionResult GetByTelefono(string numero)
        {
            try
            {
                var usuario = _usuarioService.GetByCriteria(UsuarioCriteria.Create().ByTelefono(numero));
                if (usuario == null)
                    return NoContent();

                var cuentas = _cuentaUsuarioService.GetCollectionByCriteria(CuentaUsuarioCriteria.Create().ByIdUsuario(usuario.Id.Value));
                if (cuentas == null)
                    return NoContent();

                var tiposCuenta = _tipoCuentaService.GetAll();
                var tipoConductor = tiposCuenta.FirstOrDefault(tc => tc.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase));

                if (tipoConductor == null)
                    return NoContent();

                var cuenta = cuentas.FirstOrDefault(c => c.IdTipoCuenta == tipoConductor.Id);
                if (cuenta == null)
                    return NoContent();

                return Ok(new { cuenta.Id });
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost("cuenta")]
        public IActionResult Create(CuentaUsuarioDto cuentaUsuario)
        {
            try
            {
                if (cuentaUsuario.Usuario == null)
                    throw new ArgumentException("La información para la cuenta de usuario está incompleta.");

                var tiposCuenta = _tipoCuentaService.GetAll();
                if (!tiposCuenta.Any(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase)))
                    throw new ArgumentException("No se ha encontrado el tipo de cuenta de cliente.");

                if (_usuarioService.GetByCriteria(UsuarioCriteria.Create().ByTelefono(cuentaUsuario.Usuario.Telefono)) != null)
                    throw new Exception("El número telefónico proporcionado ya se encuentra registrado");

                var cuenta = _mapper.Map<CuentaUsuario>(cuentaUsuario);
                cuenta.IdTipoCuenta = tiposCuenta.First(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase)).Id;

                var imagen = new Imagen
                {
                    Image = ImageConvertHelper.Base64ToByteArray(cuentaUsuario.Usuario.Imagen),
                    NombreImagen = cuentaUsuario.Usuario.NombreImagen
                };
                cuenta.Usuario.Imagen = imagen;

                var result = _cuentaUsuarioService.Create(cuenta);
                result.Usuario.Cuentas.Clear();
                return Created("", result.Id);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de cuenta",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de cuenta",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        #endregion
    }
}