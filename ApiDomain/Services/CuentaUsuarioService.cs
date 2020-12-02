using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class CuentaUsuarioService : ICuentaUsuarioDomainService
    {
        private readonly ICuentaUsuarioInfraestructureService _service;
        public CuentaUsuarioService(ICuentaUsuarioInfraestructureService service)
        {
            _service = service;
        }
        public CuentaUsuario Create(CuentaUsuario entity)
        {
            return _service.Create(entity);
        }

        public void Create(List<CuentaUsuario> entityCollection)
        {
            _service.Create(entityCollection);
        }
        public CuentaUsuario GetById(int id)
        {
            return _service.GetById(id);
        }
        public CuentaUsuario GetById(string id)
        {
            return _service.GetById(id);
        }
        public CuentaUsuario GetByCriteria(ICriteria<CuentaUsuario> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        public IList<CuentaUsuario> GetAll()
        {
            return _service.GetAll();
        }
        public IList<CuentaUsuario> GetCollectionByCriteria(ICriteria<CuentaUsuario> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        public void Update(CuentaUsuario entity)
        {
            _service.Update(entity);
        }

        public void Update(List<CuentaUsuario> entityCollection)
        {
            _service.Update(entityCollection);
        }
        public void Delete(CuentaUsuario entity)
        {
            _service.Delete(entity);
        }

        public void Delete(List<CuentaUsuario> entityCollection)
        {
            _service.Delete(entityCollection);
        }

    }
}