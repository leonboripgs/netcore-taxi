using ApiDomain.Entities;
using ApiDomain.Interfaces.Domain.Services;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.Shared.Data;
using System.Collections.Generic;

namespace ApiDomain.Services
{
    public class ImagenService : IImagenDomainService
    {
        private readonly IImagenInfraestructureService _service;
        public ImagenService(IImagenInfraestructureService service)
        {
            _service = service;
        }
        public Imagen Create(Imagen entity)
        {
            return _service.Create(entity);
        }

        public void Create(List<Imagen> entityCollection)
        {
            _service.Create(entityCollection);
        }
        public Imagen GetById(int id)
        {
            return _service.GetById(id);
        }
        public Imagen GetById(string id)
        {
            return _service.GetById(id);
        }
        public Imagen GetByCriteria(ICriteria<Imagen> criteria)
        {
            return _service.GetByCriteria(criteria);
        }
        public IList<Imagen> GetAll()
        {
            return _service.GetAll();
        }
        public IList<Imagen> GetCollectionByCriteria(ICriteria<Imagen> criteria)
        {
            return _service.GetCollectionByCriteria(criteria);
        }
        public void Update(Imagen entity)
        {
            _service.Update(entity);
        }

        public void Update(List<Imagen> entityCollection)
        {
            _service.Update(entityCollection);
        }
        public void Delete(Imagen entity)
        {
            _service.Delete(entity);
        }

        public void Delete(List<Imagen> entityCollection)
        {
            _service.Delete(entityCollection);
        }

    }
}