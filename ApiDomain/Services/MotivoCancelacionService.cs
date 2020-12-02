using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad MotivoCancelacion
    /// </summary>
    public class MotivoCancelacionService : IMotivoCancelacionDomainService
    {
        private readonly IMotivoCancelacionInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public MotivoCancelacionService(IMotivoCancelacionInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public MotivoCancelacion Create(MotivoCancelacion entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<MotivoCancelacion> entityCollection)
        {
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un MotivoCancelacion por su identificador
        /// </summary>
        /// <param name="id">Identificador de MotivoCancelacion</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un MotivoCancelacion por su identificador
        /// </summary>
        /// <param name="id">Identificador de MotivoCancelacion</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un MotivoCancelacion por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetByCriteria(ICriteria<MotivoCancelacion> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades MotivoCancelacion existentes en el repositorio
        /// </summary>
        /// <returns>Colección de MotivoCancelacion</returns>
        public IList<MotivoCancelacion> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades MotivoCancelacion del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de MotivoCancelacion</returns>
        public IList<MotivoCancelacion> GetCollectionByCriteria(ICriteria<MotivoCancelacion> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(MotivoCancelacion entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<MotivoCancelacion> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(MotivoCancelacion entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<MotivoCancelacion> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}
