using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    public class CuentaUsuarioRepository : ICuentaUsuarioRepository
    {
        private readonly PostgresDbContext _context;
        public CuentaUsuarioRepository(PostgresDbContext context)
        {
            _context = context;
        }
        public CuentaUsuario Create(CuentaUsuario entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Create(List<CuentaUsuario> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        public CuentaUsuario GetById(int id)
        {
            return _context.CuentasUsuario.Single(item => item.Id == id);
        }
        public CuentaUsuario GetById(string id)
        {
            throw new NotImplementedException();
        }
        public CuentaUsuario GetByCriteria(ICriteria<CuentaUsuario> criteria)
        {
            return _context.CuentasUsuario.Single(criteria.Criteria);
        }
        public IList<CuentaUsuario> GetAll()
        {
            return _context.CuentasUsuario.ToList();
        }
        public IList<CuentaUsuario> GetCollectionByCriteria(ICriteria<CuentaUsuario> criteria)
        {
            return _context.CuentasUsuario.Where(criteria.Criteria).ToList();
        }
        public void Update(CuentaUsuario entity)
        {
            _context.Update(entity);
        }

        public void Update(List<CuentaUsuario> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        public void Delete(CuentaUsuario entity)
        {
            _context.Remove(entity);
        }

        public void Delete(List<CuentaUsuario> entityCollection)
        {
            _context.RemoveRange(entityCollection);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}