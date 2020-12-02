using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class MunicipioService : IMunicipioDomainService
    {
        private readonly IMunicipioInfraestructureService _service;
        public MunicipioService(IMunicipioInfraestructureService service)
        {
            _service = service;
        }

        public IList<Municipio> GetAll()
        {
            return _service.GetAll();
        }

        public Municipio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Municipio GetById(string id)
        {
            return _service.GetById(id);
        }

        public Municipio GetByCriteria(ICriteria<Municipio> criteria)
        {
            return _service.GetByCriteria(criteria);
        }

        public IList<Municipio> GetCollectionByCriteria(ICriteria<Municipio> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
    }
}
