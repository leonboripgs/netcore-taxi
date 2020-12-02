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
    /// Repositorio de datos de la entidad CancelacionViaje
    /// </summary>
    public class CancelacionViajeRepository : ICancelacionViajeRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public CancelacionViajeRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public CancelacionViaje Create(CancelacionViaje entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<CancelacionViaje> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un CancelacionViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de CancelacionViaje</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetById(int id)
        {
            return _context.Set<CancelacionViaje>().SingleOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un CancelacionViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de CancelacionViaje</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un CancelacionViaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>CancelacionViaje</returns>
        public CancelacionViaje GetByCriteria(ICriteria<CancelacionViaje> criteria)
        {
            return _context.Set<CancelacionViaje>().SingleOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades CancelacionViaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de CancelacionViaje</returns>
        public IList<CancelacionViaje> GetAll()
        {
            return _context.Set<CancelacionViaje>().ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades CancelacionViaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de CancelacionViaje</returns>
        public IList<CancelacionViaje> GetCollectionByCriteria(ICriteria<CancelacionViaje> criteria)
        {
            return _context.Set<CancelacionViaje>().Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(CancelacionViaje entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<CancelacionViaje> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(CancelacionViaje entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<CancelacionViaje> entityCollection)
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
