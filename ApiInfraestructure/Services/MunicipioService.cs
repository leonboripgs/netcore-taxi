using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class MunicipioService : IMunicipioInfraestructureService
    {
        private readonly IMunicipioRepository _repository;
        public MunicipioService(IMunicipioRepository repository) {
            _repository = repository;
        }
        public IList<Municipio> GetAll()
        {
            return _repository.GetAll();
        }

        public Municipio GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Municipio GetByCriteria(ICriteria<Municipio> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }

        public Municipio GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"No se ha proporcionado un identicador válido.");
            return _repository.GetById(id);
        }

        public IList<Municipio> GetCollectionByCriteria(ICriteria<Municipio> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
    }
}
