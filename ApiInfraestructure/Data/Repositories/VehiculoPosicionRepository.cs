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
    /// Repositorio de datos de la entidad Vehiculo
    /// </summary>
    public class VehiculoPosicionRepository : IVehiculoPosicionRepository
    {
        private readonly PostgresDbContext _context;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public VehiculoPosicionRepository(PostgresDbContext context)
        {
            _context = context;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public VehiculoPosicion Create(VehiculoPosicion entity)
        {
            return _context.Add(entity).Entity;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<VehiculoPosicion> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>VehiculoPosicion</returns>
        public VehiculoPosicion GetById(int id)
        {
            return _context.VehiculoPosicion.FirstOrDefault(item => item.Id == id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>VehiculoPosicion</returns>
        public VehiculoPosicion GetById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtiene un Vehiculo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>VehiculoPosicion</returns>
        public VehiculoPosicion GetByCriteria(ICriteria<VehiculoPosicion> criteria)
        {
            return _context.VehiculoPosicion.FirstOrDefault(criteria.Criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Vehiculo existentes en el repositorio
        /// </summary>
        /// <returns>Colección de VehiculoPosicion</returns>
        public IList<VehiculoPosicion> GetAll()
        {
            return _context.VehiculoPosicion.ToList();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Vehiculo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de VehiculoPosicion</returns>
        public IList<VehiculoPosicion> GetCollectionByCriteria(ICriteria<VehiculoPosicion> criteria)
        {
            return _context.VehiculoPosicion.Where(criteria.Criteria).ToList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(VehiculoPosicion entity)
        {
            _context.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<VehiculoPosicion> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(VehiculoPosicion entity)
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<VehiculoPosicion> entityCollection)
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