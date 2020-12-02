using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiInfraestructure.Services
{
    public class EntidadService : IEntidadInfraestructureService
    {
        private readonly IEntidadRepository _repository;
        public EntidadService(IEntidadRepository repository) {
            _repository = repository;
        }
        public IList<Entidad> GetAll()
        {
            return _repository.GetAll();
        }

        public Entidad GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Entidad GetByCriteria(ICriteria<Entidad> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }

        public Entidad GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"No se ha proporcionado un identicador válido.");
            return _repository.GetById(id);
        }

        public IList<Entidad> GetCollectionByCriteria(ICriteria<Entidad> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
    }
}
