using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Modelo
    /// </summary>
    public class ModeloService : IModeloDomainService
    {
        private readonly IModeloInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ModeloService(IModeloInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Modelo Create(Modelo entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Modelo> entityCollection)
        {
            _service.Create(entityCollection);
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
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Modelo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Modelo</param>
        /// <returns>Modelo</returns>
        public Modelo GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Modelo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Modelo</returns>
        public Modelo GetByCriteria(ICriteria<Modelo> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Modelo existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Modelo</returns>
        public IList<Modelo> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Modelo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Modelo</returns>
        public IList<Modelo> GetCollectionByCriteria(ICriteria<Modelo> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Modelo entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Modelo> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(Modelo entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Modelo> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}