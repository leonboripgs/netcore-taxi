using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
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
    public class ModeloController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IModeloDomainService _ModeloService;
        private readonly IMapper _mapper;
        #endregion
        public ModeloController(IModeloDomainService ModeloService, IMapper mapper)
        {
            _ModeloService = ModeloService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ModeloService.GetById(id));
            }catch
            {
                return NoContent();
            }
        }
        [HttpGet("marca/{idMarca}")]
        public IActionResult GetByMarca(int idMarca)
        {
            try
            {
                return Ok(_ModeloService.GetCollectionByCriteria(new ModeloPorMarcaCriteria(idMarca)));
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
                return Ok(_ModeloService.GetAll());
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Create(ModeloDto dto)
        {
            try
            {
                var entity = _mapper.Map<Modelo>(dto);
                entity.FechaAlta = DateTime.Now;
                var saved = _ModeloService.Create(entity);
                var result = _mapper.Map<ModeloDto>(saved);
                return Created($"/api/catalogo/Modelo/{result.Id}", result);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de modelo",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de modelo",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpPut]
        public IActionResult Update(ModeloDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de Modelo válido.");

                var entity = _ModeloService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el Modelo {dto.Nombre} con el identificador {dto.Id}.");

                _mapper.Map(dto, entity);
                entity.UltimaModificacion = DateTime.Now;
                _ModeloService.Update(entity);

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de modelo",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de modelo",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        [HttpDelete]
        public IActionResult Delete(ModeloDto dto)
        {
            try
            {
                if (!dto.Id.HasValue)
                    throw new Exception("No se ha proporcionado un identificador de Modelo válido.");

                var entity = _ModeloService.GetById(dto.Id.Value);

                if (entity == null)
                    throw new Exception($"No se ha encontrado el Modelo {dto.Nombre} con el identificador {dto.Id}.");

                _ModeloService.Delete(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de modelo",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion de modelo",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
    }
}