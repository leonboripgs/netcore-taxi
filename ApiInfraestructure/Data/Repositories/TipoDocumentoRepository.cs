using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    /// <summary>
    /// Repositorio de datos de la entidad TipoDocumento
    /// </summary>
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public TipoDocumentoRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public TipoDocumento Create(TipoDocumento entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<TipoDocumento> entityCollection)
        {
            _context.AddRange(entityCollection);
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
            return _context.TiposDocumento.FirstOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un TipoDocumento por su identificador
        /// </summary>
        /// <param name="id">Identificador de TipoDocumento</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un TipoDocumento por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>TipoDocumento</returns>
        public TipoDocumento GetByCriteria(ICriteria<TipoDocumento> criteria)
        {
            return _context.TiposDocumento.FirstOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades TipoDocumento existentes en el repositorio
        /// </summary>
        /// <returns>Colección de TipoDocumento</returns>
        public IList<TipoDocumento> GetAll()
        {
            return _context.TiposDocumento.ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades TipoDocumento del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de TipoDocumento</returns>
        public IList<TipoDocumento> GetCollectionByCriteria(ICriteria<TipoDocumento> criteria)
        {
            return _context.TiposDocumento.Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(TipoDocumento entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<TipoDocumento> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(TipoDocumento entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<TipoDocumento> entityCollection)
        {
            _context.RemoveRange(entityCollection);
        }
        #endregion

        #region SAVE
        /// <summary>
        /// Guarda los cambios pendientes en el repositorio de datos
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion

    }
}
