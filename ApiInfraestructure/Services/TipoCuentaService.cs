using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class TipoCuentaService : ITipoCuentaInfraestructureService
    {
        private readonly ITipoCuentaRepository _repository;
        public TipoCuentaService(ITipoCuentaRepository repository)
        {
            _repository = repository;
        }
        public TipoCuenta Create(TipoCuenta entity)
        {
            var result =_repository.Create(entity);
            _repository.Save();
            return result;
        }

        public void Create(List<TipoCuenta> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        public TipoCuenta GetById(int id)
        {
            return _repository.GetById(id);
        }
        public TipoCuenta GetById(string id)
        {
            return _repository.GetById(id);
        }
        public TipoCuenta GetByCriteria(ICriteria<TipoCuenta> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        public IList<TipoCuenta> GetAll()
        {
            return _repository.GetAll();
        }
        public IList<TipoCuenta> GetCollectionByCriteria(ICriteria<TipoCuenta> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        public void Update(TipoCuenta entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Update(List<TipoCuenta> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
        public void Delete(TipoCuenta entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }

        public void Delete(List<TipoCuenta> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }

    }
}