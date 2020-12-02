using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    /// <summary>
    /// Servicio de datos de la entidad EstatusViaje
    /// </summary>
    public class EstatusViajeService : IEstatusViajeInfraestructureService
    {
        private readonly IEstatusViajeRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public EstatusViajeService(IEstatusViajeRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public EstatusViaje Create(EstatusViaje entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<EstatusViaje> entityCollection)
        {
            _repository.Create(entityCollection);
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
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un EstatusViaje por su identificador
        /// </summary>
        /// <param name="id">Identificador de EstatusViaje</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un EstatusViaje por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>EstatusViaje</returns>
        public EstatusViaje GetByCriteria(ICriteria<EstatusViaje> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades EstatusViaje existentes en el repositorio
        /// </summary>
        /// <returns>Colección de EstatusViaje</returns>
        public IList<EstatusViaje> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades EstatusViaje del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de EstatusViaje</returns>
        public IList<EstatusViaje> GetCollectionByCriteria(ICriteria<EstatusViaje> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(EstatusViaje entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<EstatusViaje> entityCollection)
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
        public void Delete(EstatusViaje entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<EstatusViaje> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}
