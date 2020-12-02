using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Viaje
    /// </summary>
    public class ViajeService : IViajeDomainService
    {
        private readonly IViajeInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeService(IViajeInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Viaje Create(Viaje entity)
        {
            entity.FechaAlta = DateTime.Now;
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Viaje> entityCollection)
        {
            foreach(var entity in entityCollection)
                entity.FechaAlta = DateTime.Now;
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Viaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de Viaje</param>
        /// <returns>Viaje</returns>
        public Viaje GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Viaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de Viaje</param>
        /// <returns>Viaje</returns>
        public Viaje GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Viaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Viaje</returns>
        public Viaje GetByCriteria(ICriteria<Viaje> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Viaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Viaje</returns>
        public IList<Viaje> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Viaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Viaje</returns>
        public IList<Viaje> GetCollectionByCriteria(ICriteria<Viaje> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Viaje entity)
        {
            entity.UltimaModificacion = DateTime.Now;
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Viaje> entityCollection)
        {
            foreach(var entity in entityCollection)
                entity.UltimaModificacion = DateTime.Now;
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(Viaje entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Viaje> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}
