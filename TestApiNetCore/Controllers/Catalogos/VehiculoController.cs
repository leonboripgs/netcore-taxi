using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using FaxiApiNetCore.Dtos;
using System.Linq;
using FaxiApiNetCore.Helpers;
using ApiDomain.SearchCriterias;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    //[Authorize]
    public class VehiculoController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IVehiculoDomainService _VehiculoService;
        private readonly ITipoDocumentoDomainService _tipoDocumentoService;
        private readonly IDocumentoDomainService _documentoService;
        private readonly IMapper _mapper;
        #endregion
        public VehiculoController(IVehiculoDomainService VehiculoService, ITipoDocumentoDomainService tipoDocumentoService,
                            IDocumentoDomainService documentoService, IMapper mapper)
        {
            _VehiculoService = VehiculoService;
            _tipoDocumentoService = tipoDocumentoService;
            _documentoService = documentoService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_VehiculoService.GetById(id));
            }catch
            {
                return NoContent();
            }
        }
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                Debug.WriteLine("Get All Called");
                return Ok(_VehiculoService.GetAll());
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpGet("conductor/{idConductor}")]
        public IActionResult GetByConductor(int idConductor)
        {
            try
            {
                return Ok(_VehiculoService.GetCollectionByCriteria(new VehiculoPorConductorCriteria(idConductor)));
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Create(VehiculoDto dto)
        {
            try
            {
                var entity = _mapper.Map<Vehiculo>(dto);
                entity.FechaAlta = DateTime.Now;
                var saved = _VehiculoService.Create(entity);
                var result = _mapper.Map<VehiculoDto>(saved);
                return Created($"/api/catalogo/vehiculo/{result.Id}", result);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de vehiculo",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de vehiculo",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPut]
        public IActionResult Update(VehiculoDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de vehiculo válido.");

                var entity = _VehiculoService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el vehiculo con el identificador {dto.Id}.");

                _mapper.Map(dto, entity);
                entity.UltimaModificacion = DateTime.Now;
                _VehiculoService.Update(entity);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de vehiculo",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de vehiculo",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpDelete]
        public IActionResult Delete(VehiculoDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de vehiculo válido.");

                var entity = _VehiculoService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el vehiculo con el identificador {dto.Id}.");

                _VehiculoService.Delete(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de vehiculo",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de vehiculo",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPost("tarjetacirculacion/{idVehiculo}")]
        public IActionResult CreateTarjetaCirculacion(int idVehiculo, DocumentoConductorDto documentoDto)
        {
            try
            {
                var tipoDocumento = _tipoDocumentoService.GetAll()
                    .FirstOrDefault(item => item.NombreDocumento.Equals("tarjeta_circulacion_frontal", StringComparison.InvariantCultureIgnoreCase));

                if (tipoDocumento == null)
                    throw new Exception("No existe un tipo de documento para TARJETA DE CIRCULACIÓN.");

                var documento = GuardaDocumento(idVehiculo, documentoDto, tipoDocumento);
                return Created($"api/catalogo/conductor/tarjetacirculacion/{idVehiculo}", new { documento.Id });
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
        [HttpPost("poliza/{idVehiculo}")]
        public IActionResult CreatePoliza(int idVehiculo, DocumentoConductorDto documentoDto)
        {
            try
            {
                var tipoDocumento = _tipoDocumentoService.GetAll()
                    .FirstOrDefault(item => item.NombreDocumento.Equals("poliza_frontal", StringComparison.InvariantCultureIgnoreCase));

                if (tipoDocumento == null)
                    throw new Exception("No existe un tipo de documento para POLIZA DE SEGURO.");

                var documento = GuardaDocumento(idVehiculo, documentoDto, tipoDocumento);
                return Created($"api/catalogo/conductor/poliza/{idVehiculo}", new { documento.Id });
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
        private DocumentoConductorDto GuardaDocumento(int idVehiculo, DocumentoConductorDto documentoDto, TipoDocumento tipoDocumento)
        {
            var documento = _documentoService.GetByCriteria(DocumentoCriteria.Create().ByTipoAndVehiculo(idVehiculo, tipoDocumento.Id));
            if (documento == null)
            {
                documento = new Documento
                {
                    VehiculoId = idVehiculo,
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
            documento.Imagen = null;
            return new DocumentoConductorDto
            {
                Id = documento.Id
            };
        }
    }
}