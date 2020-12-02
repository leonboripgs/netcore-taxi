using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Marca
    /// </summary>
    public class MarcaInfraestructureService : IMarcaInfraestructureService
    {
        private readonly IMarcaRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public MarcaInfraestructureService(IMarcaRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Marca Create(Marca entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Marca> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Marca por su identificador
        /// </summary>
        /// <param name="id">Identificador de Marca</param>
        /// <returns>Marca</returns>
        public Marca GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Marca por su identificador
        /// </summary>
        /// <param name="id">Identificador de Marca</param>
        /// <returns>Marca</returns>
        public Marca GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Marca por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Marca</returns>
        public Marca GetByCriteria(ICriteria<Marca> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Marca existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Marca</returns>
        public IList<Marca> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Marca del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Marca</returns>
        public IList<Marca> GetCollectionByCriteria(ICriteria<Marca> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Marca entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Marca> entityCollection)
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
        public void Delete(Marca entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Marca> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}