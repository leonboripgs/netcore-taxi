using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad Vehiculo
    /// </summary>
    public class VehiculoPosicionInfraestructureService : IVehiculoPosicionInfraestructureService
    {
        private readonly IVehiculoPosicionRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public VehiculoPosicionInfraestructureService(IVehiculoPosicionRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public VehiculoPosicion Create(VehiculoPosicion entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<VehiculoPosicion> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        #endregion

        #region READ
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>Vehiculo</returns>
        public VehiculoPosicion GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>Vehiculo</returns>
        public VehiculoPosicion GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Vehiculo</returns>
        public VehiculoPosicion GetByCriteria(ICriteria<VehiculoPosicion> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Vehiculo existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Vehiculo</returns>
        public IList<VehiculoPosicion> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Vehiculo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Vehiculo</returns>
        public IList<VehiculoPosicion> GetCollectionByCriteria(ICriteria<VehiculoPosicion> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(VehiculoPosicion entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<VehiculoPosicion> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(VehiculoPosicion entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<VehiculoPosicion> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}