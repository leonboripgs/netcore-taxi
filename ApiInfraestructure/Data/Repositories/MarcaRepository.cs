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
    /// Repositorio de datos de la entidad Marca
    /// </summary>
    public class MarcaRepository : IMarcaRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public MarcaRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Marca Create(Marca entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Marca> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Marca por su identificador
        /// </summary>
        /// <param name="id">Identificador de Marca</param>
        /// <returns>Marca</returns>
        public Marca GetById(int id)
        {
            return _context.Marcas.FirstOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un Marca por su identificador
        /// </summary>
        /// <param name="id">Identificador de Marca</param>
        /// <returns>Marca</returns>
        public Marca GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un Marca por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Marca</returns>
        public Marca GetByCriteria(ICriteria<Marca> criteria)
        {
            return _context.Marcas.FirstOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Marca existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Marca</returns>
        public IList<Marca> GetAll()
        {
            return _context.Marcas.ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Marca del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Marca</returns>
        public IList<Marca> GetCollectionByCriteria(ICriteria<Marca> criteria)
        {
            return _context.Marcas.Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Marca entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Marca> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(Marca entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Marca> entityCollection)
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