using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class UsuarioService : IUsuarioInfraestructureService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public Usuario Create(Usuario entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }

        public void Create(List<Usuario> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        public Usuario GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Usuario GetById(string id)
        {
            return _repository.GetById(id);
        }
        public Usuario GetByCriteria(ICriteria<Usuario> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        public IList<Usuario> GetAll()
        {
            return _repository.GetAll();
        }
        public IList<Usuario> GetCollectionByCriteria(ICriteria<Usuario> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        public void Update(Usuario entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Update(List<Usuario> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
        public void Delete(Usuario entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }

        public void Delete(List<Usuario> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }

    }
}