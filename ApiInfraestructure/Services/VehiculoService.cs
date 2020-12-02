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
    public class VehiculoInfraestructureService : IVehiculoInfraestructureService
    {
        private readonly IVehiculoRepository _repository;
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public VehiculoInfraestructureService(IVehiculoRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region CREATE
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Vehiculo Create(Vehiculo entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        /// <summary>
        /// Crea un conjunto de elementos nuevos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Create(List<Vehiculo> entityCollection)
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
        public Vehiculo GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por su identificador
        /// </summary>
        /// <param name="id">Identificador de Vehiculo</param>
        /// <returns>Vehiculo</returns>
        public Vehiculo GetById(string id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Obtiene un Vehiculo por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Vehiculo</returns>
        public Vehiculo GetByCriteria(ICriteria<Vehiculo> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        /// <summary>
        /// Obtiene todas la entidades Vehiculo existentes en el repositorio
        /// </summary>
        /// <returns>Colección de Vehiculo</returns>
        public IList<Vehiculo> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Obtiene un conjunto de entidades Vehiculo del repositorio por medio de un criterio de búsqueda
        /// </summary>
        /// <param name="criteria">Criterio de búsqueda</param>
        /// <returns>Colección de Vehiculo</returns>
        public IList<Vehiculo> GetCollectionByCriteria(ICriteria<Vehiculo> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Actualiza un elemento existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public void Update(Vehiculo entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Update(List<Vehiculo> entityCollection)
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
        public void Delete(Vehiculo entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        /// <summary>
        /// Elimina un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        public void Delete(List<Vehiculo> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }
        #endregion

    }
}