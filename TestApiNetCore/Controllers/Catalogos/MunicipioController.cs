using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    //[Authorize]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioDomainService _service;
        public MunicipioController(IMunicipioDomainService service)
        {
            _service = service;
        }
        [HttpGet("All")]
        public IActionResult GetAll() {
            return Ok(_service.GetAll().Select(itm => new { itm.Id, itm.Nombre, itm.EntidadId}));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id) {
            try
            {
                return Ok(_service.GetCollectionByCriteria(new ClaveMunicipioCriteria(id)));
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpGet("entidad/{entidadId}")]
        public IActionResult GetByEntidad(string entidadId)
        {
            try
            {
                return Ok(_service.GetCollectionByCriteria(new MunicipioPorEntidadCriteria(entidadId))
                        .Select(itm => new { itm.Id, itm.Nombre, itm.EntidadId }));
            }
            catch
            {
                return NoContent();
            }

        }
    }
}