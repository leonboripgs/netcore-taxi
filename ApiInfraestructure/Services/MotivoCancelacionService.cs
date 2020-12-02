using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad MotivoCancelacion
    /// </summary>
    public class MotivoCancelacionService : IMotivoCancelacionInfraestructureService
    {
        private readonly IMotivoCancelacionRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public MotivoCancelacionService(IMotivoCancelacionRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public MotivoCancelacion Create(MotivoCancelacion entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<MotivoCancelacion> entityCollection)
        {
            _repository.Create(entityCollection);
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
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un MotivoCancelacion por su identificador
        /// </summary>
        /// <param name="id">Identificador de MotivoCancelacion</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un MotivoCancelacion por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetByCriteria(ICriteria<MotivoCancelacion> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades MotivoCancelacion existentes en el repositorio
        /// </summary>
        /// <returns>Colección de MotivoCancelacion</returns>
        public IList<MotivoCancelacion> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades MotivoCancelacion del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de MotivoCancelacion</returns>
        public IList<MotivoCancelacion> GetCollectionByCriteria(ICriteria<MotivoCancelacion> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(MotivoCancelacion entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<MotivoCancelacion> entityCollection)
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
        public void Delete(MotivoCancelacion entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<MotivoCancelacion> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}
