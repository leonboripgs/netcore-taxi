using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad ViajeUsuario
    /// </summary>
    public class ViajeUsuarioService : IViajeUsuarioDomainService
    {
        private readonly IViajeUsuarioInfraestructureService _service;
        private readonly IViajeInfraestructureService _viajeService;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeUsuarioService(IViajeUsuarioInfraestructureService service, IViajeInfraestructureService viajeService)
        {
            _service = service;
            _viajeService = viajeService;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public ViajeUsuario Create(ViajeUsuario entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<ViajeUsuario> entityCollection)
        {
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un ViajeUsuario por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeUsuario</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un ViajeUsuario por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeUsuario</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un ViajeUsuario por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetByCriteria(ICriteria<ViajeUsuario> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades ViajeUsuario existentes en el repositorio
        /// </summary>
        /// <returns>Colección de ViajeUsuario</returns>
        public IList<ViajeUsuario> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades ViajeUsuario del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de ViajeUsuario</returns>
        public IList<ViajeUsuario> GetCollectionByCriteria(ICriteria<ViajeUsuario> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(ViajeUsuario entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<ViajeUsuario> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(ViajeUsuario entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<ViajeUsuario> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}
