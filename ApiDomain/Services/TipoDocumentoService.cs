using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad TipoDocumento
    /// </summary>
    public class TipoDocumentoDomainService : ITipoDocumentoDomainService
    {
        private readonly ITipoDocumentoInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public TipoDocumentoDomainService(ITipoDocumentoInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public TipoDocumento Create(TipoDocumento entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<TipoDocumento> entityCollection)
        {
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un TipoDocumento por su identificador
        /// </summary>
        /// <param name="id">Identificador de TipoDocumento</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un TipoDocumento por su identificador
        /// </summary>
        /// <param name="id">Identificador de TipoDocumento</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un TipoDocumento por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetByCriteria(ICriteria<TipoDocumento> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades TipoDocumento existentes en el repositorio
        /// </summary>
        /// <returns>Colección de TipoDocumento</returns>
        public IList<TipoDocumento> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades TipoDocumento del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de TipoDocumento</returns>
        public IList<TipoDocumento> GetCollectionByCriteria(ICriteria<TipoDocumento> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(TipoDocumento entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<TipoDocumento> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(TipoDocumento entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<TipoDocumento> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}