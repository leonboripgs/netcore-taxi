using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class CuentaUsuarioService : ICuentaUsuarioInfraestructureService
    {
        private readonly ICuentaUsuarioRepository _repository;

        public CuentaUsuarioService(ICuentaUsuarioRepository repository)
        {
            _repository = repository;
        }
        public CuentaUsuario Create(CuentaUsuario entity)
        {
            entity.Usuario.Imagen.FechaAlta = DateTime.Now;
            entity.Usuario.FechaAlta = DateTime.Now;
            entity.FechaAlta = DateTime.Now;
            
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }
        public void Create(List<CuentaUsuario> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        public CuentaUsuario GetById(int id)
        {
            return _repository.GetById(id);
        }
        public CuentaUsuario GetById(string id)
        {
            return _repository.GetById(id);
        }
        public CuentaUsuario GetByCriteria(ICriteria<CuentaUsuario> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        public IList<CuentaUsuario> GetAll()
        {
            return _repository.GetAll();
        }
        public IList<CuentaUsuario> GetCollectionByCriteria(ICriteria<CuentaUsuario> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        public void Update(CuentaUsuario entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
        public void Update(List<CuentaUsuario> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
        public void Delete(CuentaUsuario entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        public void Delete(List<CuentaUsuario> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }

    }
}