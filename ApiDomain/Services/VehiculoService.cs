using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Vehiculo
    /// </summary>
    public class VehiculoService : IVehiculoDomainService
    {
        private readonly IVehiculoInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public VehiculoService(IVehiculoInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Vehiculo Create(Vehiculo entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Vehiculo> entityCollection)
        {
            _service.Create(entityCollection);
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>Vehiculo</returns>
        public Vehiculo GetById(int id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>Vehiculo</returns>
        public Vehiculo GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Vehiculo</returns>
        public Vehiculo GetByCriteria(ICriteria<Vehiculo> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Vehiculo existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Vehiculo</returns>
        public IList<Vehiculo> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Vehiculo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Vehiculo</returns>
        public IList<Vehiculo> GetCollectionByCriteria(ICriteria<Vehiculo> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Vehiculo entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Vehiculo> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(Vehiculo entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Vehiculo> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}