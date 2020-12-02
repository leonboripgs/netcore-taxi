using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad ViajeConductor
    /// </summary>
    public class ViajeConductorService : IViajeConductorDomainService
    {
        private readonly IViajeConductorInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeConductorService(IViajeConductorInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public ViajeConductor Create(ViajeConductor entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<ViajeConductor> entityCollection)
        {
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un ViajeConductor por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeConductor</param>
        /// <returns>ViajeConductor</returns>
        public ViajeConductor GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un ViajeConductor por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeConductor</param>
        /// <returns>ViajeConductor</returns>
        public ViajeConductor GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un ViajeConductor por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>ViajeConductor</returns>
        public ViajeConductor GetByCriteria(ICriteria<ViajeConductor> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades ViajeConductor existentes en el repositorio
        /// </summary>
        /// <returns>Colección de ViajeConductor</returns>
        public IList<ViajeConductor> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades ViajeConductor del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de ViajeConductor</returns>
        public IList<ViajeConductor> GetCollectionByCriteria(ICriteria<ViajeConductor> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(ViajeConductor entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<ViajeConductor> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(ViajeConductor entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<ViajeConductor> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}
