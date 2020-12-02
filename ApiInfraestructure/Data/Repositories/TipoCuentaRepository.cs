using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    public class TipoCuentaRepository : ITipoCuentaRepository
    {
        private readonly PostgresDbContext _context;
        public TipoCuentaRepository(PostgresDbContext context)
        {
            _context = context;
        }
        public TipoCuenta Create(TipoCuenta entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Create(List<TipoCuenta> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        public TipoCuenta GetById(int id)
        {
            return _context.TiposCuenta.Single(item => item.Id == id);
        }
        public TipoCuenta GetById(string id)
        {
            throw new NotImplementedException();
        }
        public TipoCuenta GetByCriteria(ICriteria<TipoCuenta> criteria)
        {
            return _context.TiposCuenta.Single(criteria.Criteria);
        }
        public IList<TipoCuenta> GetAll()
        {
            return _context.TiposCuenta.ToList();
        }
        public IList<TipoCuenta> GetCollectionByCriteria(ICriteria<TipoCuenta> criteria)
        {
            return _context.TiposCuenta.Where(criteria.Criteria).ToList();
        }
        public void Update(TipoCuenta entity)
        {
            _context.Update(entity);
        }

        public void Update(List<TipoCuenta> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        public void Delete(TipoCuenta entity)
        {
            _context.Remove(entity);
        }

        public void Delete(List<TipoCuenta> entityCollection)
        {
            _context.RemoveRange(entityCollection);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}