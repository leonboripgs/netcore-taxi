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
    /// Repositorio de datos de la entidad EstatusViaje
    /// </summary>
    public class EstatusViajeRepository : IEstatusViajeRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public EstatusViajeRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public EstatusViaje Create(EstatusViaje entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<EstatusViaje> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un EstatusViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de EstatusViaje</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetById(int id)
        {
            return _context.Set<EstatusViaje>().SingleOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un EstatusViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de EstatusViaje</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un EstatusViaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetByCriteria(ICriteria<EstatusViaje> criteria)
        {
            return _context.Set<EstatusViaje>().SingleOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades EstatusViaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de EstatusViaje</returns>
        public IList<EstatusViaje> GetAll()
        {
            return _context.Set<EstatusViaje>().ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades EstatusViaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de EstatusViaje</returns>
        public IList<EstatusViaje> GetCollectionByCriteria(ICriteria<EstatusViaje> criteria)
        {
            return _context.Set<EstatusViaje>().Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(EstatusViaje entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<EstatusViaje> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(EstatusViaje entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<EstatusViaje> entityCollection)
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
