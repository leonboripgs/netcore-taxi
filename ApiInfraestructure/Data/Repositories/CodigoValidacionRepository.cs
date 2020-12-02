using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiInfraestructure.Data.Repositories
{
    public class CodigoValidacionRepository : ICodigoValidacionRepository
    {
        private readonly PostgresDbContext _dbContext;
        public CodigoValidacionRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(List<CodigoValidacion> entityCollection)
        {
            _dbContext.AddRange(entityCollection);
        }

        public CodigoValidacion Create(CodigoValidacion entity)
        {
            return _dbContext.Add(entity).Entity;
        }

        public void Delete(CodigoValidacion entity)
        {
            _dbContext.Remove(entity);
        }

        public void Delete(List<CodigoValidacion> entityCollection)
        {
            _dbContext.RemoveRange(entityCollection);
        }

        public IList<CodigoValidacion> GetAll()
        {
            return _dbContext.CodigosValidacion.ToList();
        }

        public CodigoValidacion GetByCriteria(ICriteria<CodigoValidacion> criteria)
        {
            return _dbContext.CodigosValidacion.Single(criteria.Criteria);
        }

        public CodigoValidacion GetById(int id)
        {
            return _dbContext.CodigosValidacion.Single(item => item.Id == id);
        }

        public CodigoValidacion GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<CodigoValidacion> GetCollectionByCriteria(ICriteria<CodigoValidacion> criteria)
        {
            return _dbContext.CodigosValidacion.Where(criteria.Criteria).ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(CodigoValidacion entity)
        {
            _dbContext.Update(entity);
        }

        public void Update(List<CodigoValidacion> entityCollection)
        {
            _dbContext.UpdateRange(entityCollection);
        }
    }
}
