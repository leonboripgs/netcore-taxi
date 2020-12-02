using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
using AutoMapper;
using FaxiApiNetCore.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Linq;

namespace ApiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    [Authorize]
    public class MotivoCancelacionController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IMotivoCancelacionDomainService _service;
        private readonly ITipoCuentaDomainService _tipoCuentaService;
        private readonly IMapper _mapper;
        #endregion
        public MotivoCancelacionController(IMotivoCancelacionDomainService service, ITipoCuentaDomainService tipoCuentaService, IMapper mapper)
        {
            _service = service;
            _tipoCuentaService = tipoCuentaService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper.Map<MotivoCancelacionDto>(_service.GetById(id));
                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.GetAll().Select(item => _mapper.Map<MotivoCancelacionDto>(item));
                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpGet("All/Cliente")]
        public IActionResult GetAllCliente()
        {
            try
            {
                var tiposCuenta = _tipoCuentaService.GetAll();
                if (!tiposCuenta.Any(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase)))
                    throw new ArgumentException("No se ha encontrado el tipo de cuenta de cliente.");

                var tipoCuenta = tiposCuenta.First(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase));
                var result = _service.GetCollectionByCriteria(MotivoCancelacionCriteria.Create().ById(tipoCuenta.Id))
                                    .Select(item => _mapper.Map<MotivoCancelacionDto>(item));

                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpGet("All/conductor")]
        public IActionResult GetAllConductor()
        {
            try
            {
                var tiposCuenta = _tipoCuentaService.GetAll();
                if (!tiposCuenta.Any(item => item.Nombre.Equals("conductor", StringComparison.InvariantCultureIgnoreCase)))
                    throw new ArgumentException("No se ha encontrado el tipo de cuenta de conductor.");

                var tipoCuenta = tiposCuenta.First(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase));
                var result = _service.GetCollectionByCriteria(MotivoCancelacionCriteria.Create().ById(tipoCuenta.Id))
                                    .Select(item => _mapper.Map<MotivoCancelacionDto>(item));

                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost("Cliente")]
        public IActionResult CreateMotivoCliente(MotivoCancelacionDto dto)
        {
            try
            {
                var tiposCuenta = _tipoCuentaService.GetAll();
                if (!tiposCuenta.Any(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase)))
                    throw new ArgumentException("No se ha encontrado el tipo de cuenta de cliente.");

                var entity = _mapper.Map<MotivoCancelacion>(dto);
                entity.FechaAlta = DateTime.Now;
                entity.IdTipoCuenta = tiposCuenta.First(item => item.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase)).Id;

                var saved = _service.Create(entity);
                var result = _mapper.Map<MotivoCancelacionDto>(saved);
                return Created($"/api/catalogo/MotivoCancelacion/{result.Id}", result);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPost("Conductor")]
        public IActionResult CreateMotivoConductor(MotivoCancelacionDto dto)
        {
            try
            {
                var tiposCuenta = _tipoCuentaService.GetAll();
                if (!tiposCuenta.Any(item => item.Nombre.Equals("conductor", StringComparison.InvariantCultureIgnoreCase)))
                    throw new ArgumentException("No se ha encontrado el tipo de cuenta de conductor.");

                var entity = _mapper.Map<MotivoCancelacion>(dto);
                entity.FechaAlta = DateTime.Now;
                entity.IdTipoCuenta = tiposCuenta.First(item => item.Nombre.Equals("conductor", StringComparison.InvariantCultureIgnoreCase)).Id;

                var saved = _service.Create(entity);
                var result = _mapper.Map<MotivoCancelacionDto>(saved);
                return Created($"/api/catalogo/MotivoCancelacion/{result.Id}", result);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPut]
        public IActionResult Update(MotivoCancelacionDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de Motivo de Cancelacion válido.");

                var entity = _service.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el Motivo de Cancelacion con el identificador {dto.Id}.");

                _mapper.Map(dto, entity);
                entity.UltimaModificacion = DateTime.Now;
                _service.Update(entity);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpDelete]
        public IActionResult Delete(MotivoCancelacionDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de Motivo de Cancelacion válido.");

                var entity = _service.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el Motivo de Cancelacion con el identificador {dto.Id}.");

                _service.Delete(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Motivo de Cancelacion",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
    }
}