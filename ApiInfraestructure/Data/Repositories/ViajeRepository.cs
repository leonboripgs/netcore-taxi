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
    /// Repositorio de datos de la entidad Viaje
    /// </summary>
    public class ViajeRepository : IViajeRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Viaje Create(Viaje entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Viaje> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Viaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de Viaje</param>
        /// <returns>Viaje</returns>
        public Viaje GetById(int id)
        {
            return _context.Set<Viaje>().SingleOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un Viaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de Viaje</param>
        /// <returns>Viaje</returns>
        public Viaje GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un Viaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Viaje</returns>
        public Viaje GetByCriteria(ICriteria<Viaje> criteria)
        {
            return _context.Set<Viaje>().SingleOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Viaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Viaje</returns>
        public IList<Viaje> GetAll()
        {
            return _context.Set<Viaje>().ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Viaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Viaje</returns>
        public IList<Viaje> GetCollectionByCriteria(ICriteria<Viaje> criteria)
        {
            return _context.Set<Viaje>().Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Viaje entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Viaje> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(Viaje entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Viaje> entityCollection)
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
