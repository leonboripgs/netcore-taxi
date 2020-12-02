using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Documento
    /// </summary>
    public class DocumentoInfraestructureService : IDocumentoInfraestructureService
    {
        private readonly IDocumentoRepository _repository;
        private readonly IImagenRepository _imageRepository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public DocumentoInfraestructureService(IDocumentoRepository repository, IImagenRepository imageRepository)
        {
            _repository = repository;
            _imageRepository = imageRepository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Documento Create(Documento entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Documento> entityCollection)
        {
            _repository.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Documento por su identificador
        /// </summary>
        /// <param name="id">Identificador de Documento</param>
        /// <returns>Documento</returns>
        public Documento GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result.ImagenId.HasValue)
                result.Imagen = _imageRepository.GetById(result.ImagenId.Value);
            return result;
        }
        /// <summary>
        /// Obtiene un Documento por su identificador
        /// </summary>
        /// <param name="id">Identificador de Documento</param>
        /// <returns>Documento</returns>
        public Documento GetById(string id)
        {
            var result = _repository.GetById(id);
            if (result.ImagenId.HasValue)
                result.Imagen = _imageRepository.GetById(result.ImagenId.Value);
            return result;
        }
        /// <summary>
        /// Obtiene un Documento por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Documento</returns>
        public Documento GetByCriteria(ICriteria<Documento> criteria)
        {
            var result = _repository.GetByCriteria(criteria);
            if (result != null && result.ImagenId.HasValue)
                result.Imagen = _imageRepository.GetById(result.ImagenId.Value);
            return result;
        }
        /// <summary>
        /// Obtiene todas la entidades Documento existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Documento</returns>
        public IList<Documento> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Documento del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Documento</returns>
        public IList<Documento> GetCollectionByCriteria(ICriteria<Documento> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Documento entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Documento> entityCollection)
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
        public void Delete(Documento entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Documento> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}