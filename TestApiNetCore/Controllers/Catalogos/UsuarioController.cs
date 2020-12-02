using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using FaxiApiNetCore.Dtos;
using FaxiApiNetCore.Helpers;

namespace FaxiApiNetCore.Controllers.Catalogos
{
    [Route("api/catalogo/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IImagenDomainService _imagenService;
        private readonly IUsuarioDomainService _usuarioService;

        public UsuarioController(IUsuarioDomainService usuarioService, IImagenDomainService imagenService)
        {
            _imagenService = imagenService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Create(UsuarioDto usuario)
        {
            Imagen imagenEntity = null;
            try
            {
                imagenEntity = new Imagen
                {
                    Image = ImageConvertHelper.Base64ToByteArray(usuario.Imagen),
                    NombreImagen = usuario.NombreImagen,
                    FechaAlta = DateTime.Now
                };                
                var usuarioEntity = new Usuario
                {
                    Nombre = usuario.Nombre,
                    ApellidoPaterno = usuario.ApellidoPaterno,
                    ApellidoMaterno = usuario.ApellidoMaterno,
                    IdEntidad = usuario.IdEntidad,
                    IdMunicipio = usuario.IdMunicipio,
                    Telefono = usuario.Telefono,
                    FechaNacimiento = usuario.FechaNacimiento,
                    FechaAlta = DateTime.Now,
                    Imagen = _imagenService.Create(imagenEntity)
                };

                var result = _usuarioService.Create(usuarioEntity);
                
                return Created("", result);
            }
            catch (DbUpdateException ex)
            {
                if (imagenEntity != null)
                    _imagenService.Delete(imagenEntity);
                return StatusCode(500, new { MessageError = (ex.InnerException as PostgresException).Detail });
            }
            catch (Exception ex)
            {
                if(imagenEntity != null)
                    _imagenService.Delete(imagenEntity);
                return StatusCode(500, new { MessageError = StringHelper.GetStringessageException(ex) });
            }
        }
    }
}