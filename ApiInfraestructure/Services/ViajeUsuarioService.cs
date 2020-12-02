using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad ViajeUsuario
    /// </summary>
    public class ViajeUsuarioService : IViajeUsuarioInfraestructureService
    {
        private readonly IViajeUsuarioRepository _repository;
        private readonly IViajeRepository _viajeRepository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeUsuarioService(IViajeUsuarioRepository repository, IViajeRepository viajeRepository)
        {
            _repository = repository;
            _viajeRepository = viajeRepository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public ViajeUsuario Create(ViajeUsuario entity)
        {
            entity.FechaAlta = DateTime.Now;
            entity.Viaje.FechaAlta = DateTime.Now;

            var result = _repository.Create(entity);
            _repository.Save();

            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<ViajeUsuario> entityCollection)
        {
            _repository.Create(entityCollection);
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
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un ViajeUsuario por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeUsuario</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un ViajeUsuario por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetByCriteria(ICriteria<ViajeUsuario> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades ViajeUsuario existentes en el repositorio
        /// </summary>
        /// <returns>Colección de ViajeUsuario</returns>
        public IList<ViajeUsuario> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades ViajeUsuario del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de ViajeUsuario</returns>
        public IList<ViajeUsuario> GetCollectionByCriteria(ICriteria<ViajeUsuario> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(ViajeUsuario entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<ViajeUsuario> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(ViajeUsuario entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<ViajeUsuario> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}
