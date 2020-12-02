using ApiDomain.Interfaces.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    [Authorize]
    public class PaisController : Controller
    {
        public readonly IPaisDomainService _service;
        public PaisController(IPaisDomainService service)
        {
            _service = service;
        }
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }catch
            {
                return NoContent();
            }
        }
    }
}