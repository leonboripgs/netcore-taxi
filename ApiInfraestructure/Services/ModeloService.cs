using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Modelo
    /// </summary>
    public class ModeloInfraestructureService : IModeloInfraestructureService
    {
        private readonly IModeloRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ModeloInfraestructureService(IModeloRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Modelo Create(Modelo entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Modelo> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Modelo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Modelo</param>
        /// <returns>Modelo</returns>
        public Modelo GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Modelo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Modelo</param>
        /// <returns>Modelo</returns>
        public Modelo GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Modelo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Modelo</returns>
        public Modelo GetByCriteria(ICriteria<Modelo> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Modelo existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Modelo</returns>
        public IList<Modelo> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Modelo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Modelo</returns>
        public IList<Modelo> GetCollectionByCriteria(ICriteria<Modelo> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Modelo entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Modelo> entityCollection)
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
        public void Delete(Modelo entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Modelo> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}