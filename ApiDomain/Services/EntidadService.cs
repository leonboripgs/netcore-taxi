using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class EntidadService : IEntidadDomainService
    {
        private readonly IEntidadInfraestructureService _service;
        public EntidadService(IEntidadInfraestructureService service)
        {
            _service = service;
        }

        public IList<Entidad> GetAll()
        {
            return _service.GetAll();
        }

        public Entidad GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Entidad GetById(string id)
        {
            return _service.GetById(id);
        }

        public Entidad GetByCriteria(ICriteria<Entidad> criteria)
        {
            return _service.GetByCriteria(criteria);
        }

        public IList<Entidad> GetCollectionByCriteria(ICriteria<Entidad> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
    }
}
