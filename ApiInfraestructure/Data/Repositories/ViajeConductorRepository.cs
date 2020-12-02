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
    /// Repositorio de datos de la entidad ViajeConductor
    /// </summary>
    public class ViajeConductorRepository : IViajeConductorRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeConductorRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public ViajeConductor Create(ViajeConductor entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<ViajeConductor> entityCollection)
        {
            _context.AddRange(entityCollection);
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
            return _context.Set<ViajeConductor>().SingleOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un ViajeConductor por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeConductor</param>
        /// <returns>ViajeConductor</returns>
        public ViajeConductor GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un ViajeConductor por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>ViajeConductor</returns>
        public ViajeConductor GetByCriteria(ICriteria<ViajeConductor> criteria)
        {
            return _context.Set<ViajeConductor>().SingleOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades ViajeConductor existentes en el repositorio
        /// </summary>
        /// <returns>Colección de ViajeConductor</returns>
        public IList<ViajeConductor> GetAll()
        {
            return _context.Set<ViajeConductor>().ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades ViajeConductor del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de ViajeConductor</returns>
        public IList<ViajeConductor> GetCollectionByCriteria(ICriteria<ViajeConductor> criteria)
        {
            return _context.Set<ViajeConductor>().Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(ViajeConductor entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<ViajeConductor> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(ViajeConductor entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<ViajeConductor> entityCollection)
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
