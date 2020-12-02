using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiInfraestructure.Services
{
    public class ImagenService : IImagenInfraestructureService
    {
        private readonly IImagenRepository _repository;
        public ImagenService(IImagenRepository repository)
        {
            _repository = repository;
        }
        public Imagen Create(Imagen entity)
        {
            var result = _repository.Create(entity);
            _repository.Save();
            return result;
        }

        public void Create(List<Imagen> entityCollection)
        {
            _repository.Create(entityCollection);
            _repository.Save();
        }
        public Imagen GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Imagen GetById(string id)
        {
            return _repository.GetById(id);
        }
        public Imagen GetByCriteria(ICriteria<Imagen> criteria)
        {
            return _repository.GetByCriteria(criteria);
        }
        public IList<Imagen> GetAll()
        {
            return _repository.GetAll();
        }
        public IList<Imagen> GetCollectionByCriteria(ICriteria<Imagen> criteria)
        {
            return _repository.GetCollectionByCriteria(criteria);
        }
        public void Update(Imagen entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Update(List<Imagen> entityCollection)
        {
            _repository.Update(entityCollection);
            _repository.Save();
        }
        public void Delete(Imagen entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }

        public void Delete(List<Imagen> entityCollection)
        {
            _repository.Delete(entityCollection);
            _repository.Save();
        }

    }
}