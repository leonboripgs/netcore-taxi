using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class PaisService : IPaisInfraestructureService
    {
        private readonly IPaisRepository _repository;
        public PaisService(IPaisRepository repository)
        {
            _repository = repository;
        }
        public IList<Pais> GetAll()
        {
            return _repository.GetAll();
        }

        public Pais GetByCriteria(ICriteria<Pais> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }

        public Pais GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Pais GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"No se ha proporcionado un identicador válido.");
            return _repository.GetById(id);
        }

        public IList<Pais> GetCollectionByCriteria(ICriteria<Pais> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
    }
}
