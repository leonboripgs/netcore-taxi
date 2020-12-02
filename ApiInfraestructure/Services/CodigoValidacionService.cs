using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class CodigoValidacionService : ICodigoValidacionInfraestructureService
    {
        private readonly ICodigoValidacionRepository _repository;
        public CodigoValidacionService(ICodigoValidacionRepository repository)
        {
            _repository = repository;
        }
        public CodigoValidacion Create(CodigoValidacion entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }

        public void Create(List<CodigoValidacion> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }

        public void Delete(CodigoValidacion entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }

        public void Delete(List<CodigoValidacion> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }

        public IList<CodigoValidacion> GetAll() => _repository.GetAll();

        public CodigoValidacion GetByCriteria(ICriteria<CodigoValidacion> criteria) => _repository.GetByCriteria(criteria);

        public CodigoValidacion GetById(int id) => _repository.GetById(id);

        public CodigoValidacion GetById(string id) => _repository.GetById(id);

        public IList<CodigoValidacion> GetCollectionByCriteria(ICriteria<CodigoValidacion> criteria) => _repository.GetCollectionByCriteria(criteria);

        public void Update(CodigoValidacion entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Update(List<CodigoValidacion> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
    }
}
