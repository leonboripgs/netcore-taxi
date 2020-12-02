using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using AutoMapper;
using FaxiApiNetCore.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    public class EstatusViajeController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IEstatusViajeDomainService _EstatusViajeService;
        private readonly IMapper _mapper;
        #endregion
        public EstatusViajeController(IEstatusViajeDomainService EstatusViajeService, IMapper mapper)
        {
            _EstatusViajeService = EstatusViajeService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_EstatusViajeService.GetById(id));
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
                return Ok(_EstatusViajeService.GetAll());
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Create(EstatusViajeDto dto)
        {
            try
            {
                var entity = _mapper.Map<EstatusViaje>(dto);
                entity.FechaAlta = DateTime.Now;
                var saved = _EstatusViajeService.Create(entity);
                var result = _mapper.Map<EstatusViajeDto>(saved);
                return Created($"/api/catalogo/EstatusViaje/{result.Id}", result);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Estatus de Viaje",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Estatus de Viaje",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPut]
        public IActionResult Update(EstatusViajeDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de Estatus de Viaje válido.");

                var entity = _EstatusViajeService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el Estatus de Viaje {dto.Nombre} con el identificador {dto.Id}.");

                _mapper.Map(dto, entity);
                entity.UltimaModificacion = DateTime.Now;
                _EstatusViajeService.Update(entity);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Estatus de Viaje",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Estatus de Viaje",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpDelete]
        public IActionResult Delete(EstatusViajeDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de Estatus de Viaje válido.");

                var entity = _EstatusViajeService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el Estatus de Viaje {dto.Nombre} con el identificador {dto.Id}.");

                _EstatusViajeService.Delete(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Estatus de Viaje",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de Estatus de Viaje",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
    }
}