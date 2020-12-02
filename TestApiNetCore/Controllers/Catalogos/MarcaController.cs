using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using FaxiApiNetCore.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    [Authorize]
    public class MarcaController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IMarcaDomainService _marcaService;
        private readonly IMapper _mapper;
        #endregion
        public MarcaController(IMarcaDomainService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_marcaService.GetById(id));
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
                return Ok(_marcaService.GetAll());
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Create(MarcaDto dto)
        {
            try
            {
                var entity = _mapper.Map<Marca>(dto);
                entity.FechaAlta = DateTime.Now;
                var saved = _marcaService.Create(entity);
                var result = _mapper.Map<MarcaDto>(saved);
                return Created($"/api/catalogo/marca/{result.Id}", result);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de marca",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de marca",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPut]
        public IActionResult Update(MarcaDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de marca válido.");

                var entity = _marcaService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado la marca {dto.Nombre} con el identificador {dto.Id}.");

                _mapper.Map(dto, entity);
                entity.UltimaModificacion = DateTime.Now;
                _marcaService.Update(entity);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de marca",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de marca",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpDelete]
        public IActionResult Delete(MarcaDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de marca válido.");

                var entity = _marcaService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado la marca {dto.Nombre} con el identificador {dto.Id}.");

                _marcaService.Delete(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de marca",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de marca",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
    }
}