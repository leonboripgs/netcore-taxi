using ApiDomain.Exceptions;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    [Authorize]
    public class EntidadController : ControllerBase
    {
        private readonly IEntidadDomainService _service;
        public EntidadController(IEntidadDomainService service)
        {
            _service = service;
        }
        [HttpGet("All")]
        public IActionResult GetAll() {
            return Ok(_service.GetAll().Select(itm => new { itm.Id, itm.Nombre }));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id) {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpGet("pais/{paisId}")]
        public IActionResult GetByPais(string paisId)
        {
            try
            {
                return Ok(_service.GetCollectionByCriteria(new EntidadPorPaisCriteria(paisId))
                                    .Select(itm => new { itm.Id, itm.Nombre }));
            }
            catch
            {
                return NoContent();
            }

        }
    }
}