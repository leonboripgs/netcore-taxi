using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad TipoDocumento
    /// </summary>
    public class TipoDocumentoInfraestructureService : ITipoDocumentoInfraestructureService
    {
        private readonly ITipoDocumentoRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public TipoDocumentoInfraestructureService(ITipoDocumentoRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public TipoDocumento Create(TipoDocumento entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<TipoDocumento> entityCollection)
        {
            _repository.Create(entityCollection);
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
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un TipoDocumento por su identificador
        /// </summary>
        /// <param name="id">Identificador de TipoDocumento</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un TipoDocumento por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetByCriteria(ICriteria<TipoDocumento> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades TipoDocumento existentes en el repositorio
        /// </summary>
        /// <returns>Colección de TipoDocumento</returns>
        public IList<TipoDocumento> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades TipoDocumento del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de TipoDocumento</returns>
        public IList<TipoDocumento> GetCollectionByCriteria(ICriteria<TipoDocumento> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(TipoDocumento entity)
        {
            _repository.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<TipoDocumento> entityCollection)
        {
            _repository.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(TipoDocumento entity)
        {
            _repository.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<TipoDocumento> entityCollection)
        {
            _repository.Delete(entityCollection);
        }

        TipoDocumento ICreate<TipoDocumento>.Create(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}