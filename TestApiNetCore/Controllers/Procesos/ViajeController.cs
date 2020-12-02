using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.SearchCriterias;
using AutoMapper;
using FaxiApiNetCore.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ApiApiNetCore.Controllers.Procesos
{
    [Route("api/proceso/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        #region ATTRIBUTES
        private readonly IViajeDomainService _viajeService;
        private readonly IViajeUsuarioDomainService _viajeUsuarioService;
        private readonly IEstatusViajeDomainService _estatusViajeService;
        private readonly ICuentaUsuarioDomainService _cuentaUsuarioService;
        private readonly ITipoCuentaDomainService _tipoCuentaService;
        private readonly IMapper _mapper;
        #endregion
        #region CONSTRUCTORS
        public ViajeController(IViajeDomainService viajeService, IViajeUsuarioDomainService viajeUsuarioService, IEstatusViajeDomainService estatusViajeService, ICuentaUsuarioDomainService cuentaUsuarioService, 
            ITipoCuentaDomainService tipoCuentaService, IMapper mapper)
        {
            _viajeService = viajeService;
            _viajeUsuarioService = viajeUsuarioService;
            _estatusViajeService = estatusViajeService;
            _cuentaUsuarioService = cuentaUsuarioService;
            _tipoCuentaService = tipoCuentaService;
            _mapper = mapper;
        }
        #endregion
        #region METHODS
        [HttpPost("{idUsuario}")]
        public IActionResult Create(int idUsuario, ViajeDto dto)
        {
            try
            {
                var usuario = _cuentaUsuarioService.GetById(idUsuario);
                if (usuario == null)
                    throw new Exception("No existe la cuenta de usuario proporcionada.");

                var tipoCuenta = _tipoCuentaService.GetById(usuario.IdTipoCuenta);
                if (!tipoCuenta.Nombre.Equals("cliente", StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception("La cuenta proporcionada no pertenece a un cliente.");

                var estatus = _estatusViajeService.GetByCriteria(EstatusViajeCriteria.Create().ByNombre("pendiente"));
                if (estatus == null)
                    throw new Exception("No se encuentra registrado es esatus de viaje PENDIENTE.");

                var viajeUsuario = new ViajeUsuario
                {
                    ClienteId = idUsuario,
                    Viaje = _mapper.Map<Viaje>(dto)
                };
                viajeUsuario.Viaje.EstatusViajeId = estatus.Id.Value;
                _viajeUsuarioService.Create(viajeUsuario);

                return Ok(viajeUsuario.Viaje.Id);
            }
            catch (DbUpdateException ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion del viaje",
                    Detail = (ex.InnerException as PostgresException).Detail
                };
                return ValidationProblem(error);
            }
            catch (ArgumentNullException aex) {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion del viaje",
                    Detail = aex.Message
                };
                return ValidationProblem(error);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails
                {
                    Title = "Error de creacion del viaje",
                    Detail = ex.Message
                };
                return ValidationProblem(error);
            }
        }
        #endregion
    }
}