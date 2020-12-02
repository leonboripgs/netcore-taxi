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
    /// Repositorio de datos de la entidad MotivoCancelacion
    /// </summary>
    public class MotivoCancelacionRepository : IMotivoCancelacionRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public MotivoCancelacionRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public MotivoCancelacion Create(MotivoCancelacion entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<MotivoCancelacion> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un MotivoCancelacion por su identificador
        /// </summary>
        /// <param name="id">Identificador de MotivoCancelacion</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetById(int id)
        {
            return _context.Set<MotivoCancelacion>().SingleOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un MotivoCancelacion por su identificador
        /// </summary>
        /// <param name="id">Identificador de MotivoCancelacion</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un MotivoCancelacion por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>MotivoCancelacion</returns>
        public MotivoCancelacion GetByCriteria(ICriteria<MotivoCancelacion> criteria)
        {
            return _context.Set<MotivoCancelacion>().SingleOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades MotivoCancelacion existentes en el repositorio
        /// </summary>
        /// <returns>Colección de MotivoCancelacion</returns>
        public IList<MotivoCancelacion> GetAll()
        {
            return _context.Set<MotivoCancelacion>().ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades MotivoCancelacion del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de MotivoCancelacion</returns>
        public IList<MotivoCancelacion> GetCollectionByCriteria(ICriteria<MotivoCancelacion> criteria)
        {
            return _context.Set<MotivoCancelacion>().Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(MotivoCancelacion entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<MotivoCancelacion> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(MotivoCancelacion entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<MotivoCancelacion> entityCollection)
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
