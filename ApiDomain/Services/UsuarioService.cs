using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class UsuarioService : IUsuarioDomainService
    {
        private readonly IUsuarioInfraestructureService _service;
        public UsuarioService(IUsuarioInfraestructureService service)
        {
            _service = service;
        }
        public Usuario Create(Usuario entity)
        {
            return _service.Create(entity);
        }
        public void Create(List<Usuario> entityCollection)
        {
            _service.Create(entityCollection);
        }
        public Usuario GetById(int id)
        {
            return _service.GetById(id);
        }
        public Usuario GetById(string id)
        {
            return _service.GetById(id);
        }
        public Usuario GetByCriteria(ICriteria<Usuario> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        public IList<Usuario> GetAll()
        {
            return _service.GetAll();
        }
        public IList<Usuario> GetCollectionByCriteria(ICriteria<Usuario> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        public void Update(Usuario entity)
        {
            _service.Update(entity);
        }
        public void Update(List<Usuario> entityCollection)
        {
            _service.Update(entityCollection);
        }
        public void Delete(Usuario entity)
        {
            _service.Delete(entity);
        }
        public void Delete(List<Usuario> entityCollection)
        {
            _service.Delete(entityCollection);
        }

    }
}