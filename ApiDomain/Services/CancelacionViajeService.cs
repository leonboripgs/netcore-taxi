using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad CancelacionViaje
    /// </summary>
    public class CancelacionViajeService : ICancelacionViajeDomainService
    {
        private readonly ICancelacionViajeInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public CancelacionViajeService(ICancelacionViajeInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public CancelacionViaje Create(CancelacionViaje entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<CancelacionViaje> entityCollection)
        {
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un CancelacionViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de CancelacionViaje</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un CancelacionViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de CancelacionViaje</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un CancelacionViaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetByCriteria(ICriteria<CancelacionViaje> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades CancelacionViaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de CancelacionViaje</returns>
        public IList<CancelacionViaje> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades CancelacionViaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de CancelacionViaje</returns>
        public IList<CancelacionViaje> GetCollectionByCriteria(ICriteria<CancelacionViaje> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(CancelacionViaje entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<CancelacionViaje> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(CancelacionViaje entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<CancelacionViaje> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}
