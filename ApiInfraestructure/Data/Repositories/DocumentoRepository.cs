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
    /// Repositorio de datos de la entidad Documento
    /// </summary>
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public DocumentoRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Documento Create(Documento entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Documento> entityCollection)
        {
            _context.AddRange(entityCollection);
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
            return _context.Documentos.FirstOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un Documento por su identificador
        /// </summary>
        /// <param name="id">Identificador de Documento</param>
        /// <returns>Documento</returns>
        public Documento GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un Documento por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Documento</returns>
        public Documento GetByCriteria(ICriteria<Documento> criteria)
        {
            return _context.Documentos.FirstOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Documento existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Documento</returns>
        public IList<Documento> GetAll()
        {
            return _context.Documentos.ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Documento del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Documento</returns>
        public IList<Documento> GetCollectionByCriteria(ICriteria<Documento> criteria)
        {
            return _context.Documentos.Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Documento entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Documento> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(Documento entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Documento> entityCollection)
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
