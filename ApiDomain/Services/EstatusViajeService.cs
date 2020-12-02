using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    /// <summary>
    /// Servicio de datos de la entidad EstatusViaje
    /// </summary>
    public class EstatusViajeService : IEstatusViajeDomainService
    {
        private readonly IEstatusViajeInfraestructureService _service;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public EstatusViajeService(IEstatusViajeInfraestructureService service)
        {
            _service = service;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public EstatusViaje Create(EstatusViaje entity)
        {
            return _service.Create(entity);
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<EstatusViaje> entityCollection)
        {
            _service.Create(entityCollection);
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
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un EstatusViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de EstatusViaje</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetById(string id)
        {
            return _service.GetById(id);
        }
        /// <summary>
        /// Obtiene un EstatusViaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetByCriteria(ICriteria<EstatusViaje> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades EstatusViaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de EstatusViaje</returns>
        public IList<EstatusViaje> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades EstatusViaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de EstatusViaje</returns>
        public IList<EstatusViaje> GetCollectionByCriteria(ICriteria<EstatusViaje> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(EstatusViaje entity)
        {
            _service.Update(entity);
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<EstatusViaje> entityCollection)
        {
            _service.Update(entityCollection);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Elimina un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Delete(EstatusViaje entity)
        {
            _service.Delete(entity);
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<EstatusViaje> entityCollection)
        {
            _service.Delete(entityCollection);
        }
        #endregion

    }
}
