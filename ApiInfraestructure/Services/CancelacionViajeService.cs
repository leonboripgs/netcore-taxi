using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad CancelacionViaje
    /// </summary>
    public class CancelacionViajeService : ICancelacionViajeInfraestructureService
    {
        private readonly ICancelacionViajeRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public CancelacionViajeService(ICancelacionViajeRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public CancelacionViaje Create(CancelacionViaje entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<CancelacionViaje> entityCollection)
        {
            _repository.Create(entityCollection);
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
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un CancelacionViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de CancelacionViaje</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un CancelacionViaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetByCriteria(ICriteria<CancelacionViaje> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades CancelacionViaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de CancelacionViaje</returns>
        public IList<CancelacionViaje> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades CancelacionViaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de CancelacionViaje</returns>
        public IList<CancelacionViaje> GetCollectionByCriteria(ICriteria<CancelacionViaje> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(CancelacionViaje entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<CancelacionViaje> entityCollection)
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
        public void Delete(CancelacionViaje entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<CancelacionViaje> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}
