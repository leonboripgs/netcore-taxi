using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class PaisService : IPaisDomainService
    {
        private readonly IPaisInfraestructureService _service;
        public PaisService(IPaisInfraestructureService service)
        {
            _service = service;
        }
        public IList<Pais> GetAll()
        {
            return _service.GetAll();
        }

        public Pais GetById(int id)
        {
            return _service.GetById(id);
        }

        public Pais GetById(string id)
        {
            return _service.GetById(id);
        }

        public Pais GetByCriteria(ICriteria<Pais> criteria)
        {
            return _service.GetByCriteria(criteria);
        }

        public IList<Pais> GetCollectionByCriteria(ICriteria<Pais> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
    }
}
