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
    /// Repositorio de datos de la entidad ViajeUsuario
    /// </summary>
    public class ViajeUsuarioRepository : IViajeUsuarioRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public ViajeUsuarioRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public ViajeUsuario Create(ViajeUsuario entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<ViajeUsuario> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un ViajeUsuario por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeUsuario</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetById(int id)
        {
            return _context.Set<ViajeUsuario>().SingleOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un ViajeUsuario por su identificador
        /// </summary>
        /// <param name="id">Identificador de ViajeUsuario</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un ViajeUsuario por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>ViajeUsuario</returns>
        public ViajeUsuario GetByCriteria(ICriteria<ViajeUsuario> criteria)
        {
            return _context.Set<ViajeUsuario>().SingleOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades ViajeUsuario existentes en el repositorio
        /// </summary>
        /// <returns>Colección de ViajeUsuario</returns>
        public IList<ViajeUsuario> GetAll()
        {
            return _context.Set<ViajeUsuario>().ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades ViajeUsuario del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de ViajeUsuario</returns>
        public IList<ViajeUsuario> GetCollectionByCriteria(ICriteria<ViajeUsuario> criteria)
        {
            return _context.Set<ViajeUsuario>().Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(ViajeUsuario entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<ViajeUsuario> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(ViajeUsuario entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<ViajeUsuario> entityCollection)
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
