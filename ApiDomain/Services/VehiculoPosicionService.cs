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
    public class VehiculoPosicionService : IVehiculoPosicionDomainService
    {
        private readonly IVehiculoPosicionInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public VehiculoPosicionService(IVehiculoPosicionInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public VehiculoPosicion Create(VehiculoPosicion entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<VehiculoPosicion> entityCollection)
        {
            _service.Create(entityCollection);
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
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>VehiculoPosicion</returns>
        public VehiculoPosicion GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Vehiculo</returns>
        public VehiculoPosicion GetByCriteria(ICriteria<VehiculoPosicion> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades VehiculoPosicion existentes en el repositorio
        /// </summary>
        /// <returns>Colección de VehiculoPosicion</returns>
        public IList<VehiculoPosicion> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Vehiculo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de VehiculoPosicion</returns>
        public IList<VehiculoPosicion> GetCollectionByCriteria(ICriteria<VehiculoPosicion> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(VehiculoPosicion entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<VehiculoPosicion> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(VehiculoPosicion entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<VehiculoPosicion> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}