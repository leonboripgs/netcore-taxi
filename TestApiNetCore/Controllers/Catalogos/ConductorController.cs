using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
using AutoMapper;
using FaxiApiNetCore.Dtos;
using FaxiApiNetCore.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Linq;
using System.Device.Location;
using System.Collections.Generic;
using ApiInfraestructure.Data.Contexts;
using Newtonsoft.Json;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    [Authorize]
    public class ConductorController : ControllerBase
    {
        private readonly PostgresDbContext _context;
        #region ATTRIBUTES
        private readonly IUsuarioDomainService _usuarioService;
        private readonly ICuentaUsuarioDomainService _cuentaUsuarioService;
        private readonly ITipoCuentaDomainService _tipoCuentaService;
        private readonly IMapper _mapper;
        private readonly IDocumentoDomainService _documentoService;
        private readonly ITipoDocumentoDomainService _tipoDocumentoService;
        private readonly string _baseUrl;
        #endregion
        #region CONSTRUCTOR
        public ConductorController(ICuentaUsuarioDomainService cuentaUsuarioService, IUsuarioDomainService usuarioService, ITipoCuentaDomainService tipoCuentaService,
            IDocumentoDomainService documentoService, ITipoDocumentoDomainService tipoDocumentoService, IMapper mapper, PostgresDbContext context)
        {
            _usuarioService = usuarioService;
            _cuentaUsuarioService = cuentaUsuarioService;
            _tipoCuentaService = tipoCuentaService;
            _documentoService = documentoService;
            _tipoDocumentoService = tipoDocumentoService;
            _mapper = mapper;
            _baseUrl = string.Empty;
            _context = context;
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
                var tipoConductor = tiposCuenta.FirstOrDefault(tc => tc.Nombre.Equals("conductor", StringComparison.InvariantCultureIgnoreCase));

                if (tipoConductor == null)
                    return NoContent();

                var cuenta = cuentas.FirstOrDefault(c => c.IdTipoCuenta == tipoConductor.Id);
                if (cuenta == null)
                    return NoContent();

                return Ok(new { cuenta.Id });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("cuenta")]
        public IActionResult Create(CuentaUsuarioDto cuentaUsuario){
            try
            {
                if (cuentaUsuario.Usuario == null)
                    throw new ArgumentException("La información para la cuenta de usuario está incompleta.");

                var tiposCuenta = _tipoCuentaService.GetAll();
                if(!tiposCuenta.Any(item => item.Nombre.Equals("conductor", StringComparison.InvariantCultureIgnoreCase)))
                    throw new ArgumentException("No se ha encontrado el tipo de cuenta de conductor.");

                if (_usuarioService.GetByCriteria(UsuarioCriteria.Create().ByTelefono(cuentaUsuario.Usuario.Telefono)) != null)
                    throw new Exception("El número telefónico proporcionado ya se encuentra registrado");

                var cuenta = _mapper.Map<CuentaUsuario>(cuentaUsuario);
                cuenta.IdTipoCuenta = tiposCuenta.First(item => item.Nombre.Equals("conductor", StringComparison.InvariantCultureIgnoreCase)).Id;
                
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
                var error = new ValidationProblemDetails {
                    Title = "Error de creacion de cuenta",
                    Detail= (ex.InnerException as PostgresException).Detail
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
        [HttpPost("ine/frontal/{idCuenta}")]
        public IActionResult CreateIne(int idCuenta, DocumentoConductorDto documentoDto)
        {
            try
            {
                var tipoDocumento = _tipoDocumentoService.GetAll()
                    .FirstOrDefault(item => item.NombreDocumento.Equals("ine_frontal", StringComparison.InvariantCultureIgnoreCase));

                if (tipoDocumento == null)
                    throw new Exception("No existe un tipo de documento para INE frontal.");
                
                var documento = GuardaDocumento(idCuenta, documentoDto, tipoDocumento);
                return Created($"{_baseUrl}/api/catalogo/conductor/ine/frontal/{idCuenta}", new { documento.Id });
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
        [HttpPost("ine/trasera/{idCuenta}")]
        public IActionResult CreateIneTrasera(int idCuenta, DocumentoConductorDto documentoDto)
        {
            try
            {
                var tipoDocumento = _tipoDocumentoService.GetAll()
                    .FirstOrDefault(item => item.NombreDocumento.Equals("ine_trasera", StringComparison.InvariantCultureIgnoreCase));

                if (tipoDocumento == null)
                    throw new Exception("No existe un tipo de documento para INE trasera.");

                var documento = GuardaDocumento(idCuenta, documentoDto, tipoDocumento);
                return Created($"{_baseUrl}/api/catalogo/conductor/ine/trasera/{idCuenta}", new { documento.Id });
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
        [HttpPost("licencia/{idCuenta}")]
        public IActionResult CreateLicencia(int idCuenta, DocumentoConductorDto documentoDto)
        {
            try
            {
                var tipoDocumento = _tipoDocumentoService.GetAll()
                    .FirstOrDefault(item => item.NombreDocumento.Equals("licencia_frontal", StringComparison.InvariantCultureIgnoreCase));

                if (tipoDocumento == null)
                    throw new Exception("No existe un tipo de documento para LICENCIA DE CONDUCIR.");

                var documento = GuardaDocumento(idCuenta, documentoDto, tipoDocumento);                
                return Created($"{_baseUrl}/api/catalogo/conductor/licencia/{idCuenta}", new { documento.Id });
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
        [HttpGet("nearby_drivers")]
        public IActionResult GetNearByDrivers([FromQuery]string lat, [FromQuery]string lng)
        {
            var activeUsuarioEntities = _context.CuentasUsuario.Where<CuentaUsuario>(s => s.EnServicio == true && s.IdTipoCuenta == 1);
            int requestedDriverCnt = 0;
            List<DriverLocation> driverList = new List<DriverLocation>();
            // Finding List of drivers in 10km
            foreach (var entity in activeUsuarioEntities)
            {
                if (requestedDriverCnt == 10)
                {
                    break;
                }
                var viajeConductor = _context.ViajesConductores.Where(s => s.IdConductor == entity.Id).Last<ViajeConductor>();
                if (viajeConductor.Viaje.EstatusViajeId == 1)
                {
                    var driverPositionEntity = _context.VehiculoPosicion.Where(s => s.IdCuentaUsuario == entity.Id).First<VehiculoPosicion>();

                    GeoCoordinate clientPosition = new GeoCoordinate(double.Parse(lat), double.Parse(lng));
                    GeoCoordinate driverPosition = new GeoCoordinate(driverPositionEntity.Latitud, driverPositionEntity.Longitud);
                    double distance = clientPosition.GetDistanceTo(driverPosition);
                    if (distance < 10000)
                    {
                        // Add Driver Data to List Wit Coordinate Data
                        driverList.Add(
                            new DriverLocation
                            {
                                Id = (int)entity.Id,
                                Location = new CoordinateData
                                {
                                    Latitud = driverPositionEntity.Latitud,
                                    Longitud = driverPositionEntity.Longitud
                                }
                            }
                        );
                    }
                }
            }
            return Ok(new {
                NearByDrivers = driverList
            });
        }
        private DocumentoConductorDto GuardaDocumento(int idCuenta, DocumentoConductorDto documentoDto, TipoDocumento tipoDocumento)
        {
            var documento = _documentoService.GetByCriteria(DocumentoCriteria.Create().ByTipoAndCuenta(idCuenta, tipoDocumento.Id));
            if (documento == null)
            {
                documento = new Documento
                {
                    CuentaUsuarioId = idCuenta,
                    TipoDocumentoId = tipoDocumento.Id,
                    Referencia = documentoDto.Referencia,
                    Vigencia = documentoDto.Vigencia,
                    Imagen = new Imagen
                    {
                        Image = ImageConvertHelper.Base64ToByteArray(documentoDto.Imagen),
                        NombreImagen = documentoDto.Nombre,
                        FechaAlta = DateTime.Now
                    }
                };
                _documentoService.Create(documento);
            }
            else
            {
                documento.Referencia = documentoDto.Referencia;
                documento.Vigencia = documentoDto.Vigencia;
                documento.Imagen.Image = ImageConvertHelper.Base64ToByteArray(documentoDto.Imagen);
                documento.Imagen.NombreImagen = documentoDto.Nombre;
                documento.Imagen.UltimaModificacion = DateTime.Now;
                _documentoService.Update(documento);
            }
            return new DocumentoConductorDto
            {
                Id = documento.Id
            };
        }
        #endregion
        private class CoordinateData
        {
            public double Latitud { get; set; }
            public double Longitud { get; set; }
        }
        private class DriverLocation
        {
            public int Id { get; set; }
            public CoordinateData Location { get; set; }
        }
    }
}