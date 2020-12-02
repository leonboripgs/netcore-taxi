using ApiDomain.Entities;
using ApiDomain.Exceptions;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class TipoCuentaService : ITipoCuentaDomainService
    {
        private readonly ITipoCuentaInfraestructureService _service;
        public TipoCuentaService(ITipoCuentaInfraestructureService service)
        {
            _service = service;
        }
        public TipoCuenta Create(TipoCuenta entity)
        {
            return _service.Create(entity);
        }

        public void Create(List<TipoCuenta> entityCollection)
        {
            _service.Create(entityCollection);
        }
        public TipoCuenta GetById(int id)
        {
            return _service.GetById(id);
        }
        public TipoCuenta GetById(string id)
        {
            return _service.GetById(id);
        }
        public TipoCuenta GetByCriteria(ICriteria<TipoCuenta> criteria)
        {
            try
            {
                return _service.GetByCriteria(criteria);
            }catch(Exception ex)
            {
                throw new ServiceException("No se ha encontrado el tipo de cuenta solicitado.", ex);
            }
        }
        public IList<TipoCuenta> GetAll()
        {
            return _service.GetAll();
        }
        public IList<TipoCuenta> GetCollectionByCriteria(ICriteria<TipoCuenta> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        public void Update(TipoCuenta entity)
        {
            _service.Update(entity);
        }

        public void Update(List<TipoCuenta> entityCollection)
        {
            _service.Update(entityCollection);
        }
        public void Delete(TipoCuenta entity)
        {
            _service.Delete(entity);
        }

        public void Delete(List<TipoCuenta> entityCollection)
        {
            _service.Delete(entityCollection);
        }

    }
}