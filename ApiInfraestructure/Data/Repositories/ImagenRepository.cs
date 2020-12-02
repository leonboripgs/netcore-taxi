using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    public class ImagenRepository : IImagenRepository
    {
        private readonly PostgresDbContext _context;
        public ImagenRepository(PostgresDbContext context)
        {
            _context = context;
        }
        public Imagen Create(Imagen entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Create(List<Imagen> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        public Imagen GetById(int id)
        {
            return _context.Imagenes.Single(item => item.Id == id);
        }
        public Imagen GetById(string id)
        {
            throw new NotImplementedException();
        }
        public Imagen GetByCriteria(ICriteria<Imagen> criteria)
        {
            return _context.Imagenes.Single(criteria.Criteria);
        }
        public IList<Imagen> GetAll()
        {
            return _context.Imagenes.ToList();
        }
        public IList<Imagen> GetCollectionByCriteria(ICriteria<Imagen> criteria)
        {
            return _context.Imagenes.Where(criteria.Criteria).ToList();
        }
        public void Update(Imagen entity)
        {
            _context.Update(entity);
        }

        public void Update(List<Imagen> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        public void Delete(Imagen entity)
        {
            _context.Remove(entity);
        }

        public void Delete(List<Imagen> entityCollection)
        {
            _context.RemoveRange(entityCollection);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}