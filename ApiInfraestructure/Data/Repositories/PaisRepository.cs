using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly PostgresDbContext _dbContext;
        public PaisRepository(PostgresDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IList<Pais> GetAll()
        {
            return _dbContext.Paises.ToList();
        }

        public Pais GetByCriteria(ICriteria<Pais> criteria)
        {
            return _dbContext.Paises.Single(criteria.Criteria);
        }

        public Pais GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Pais GetById(string id)
        {
            return _dbContext.Paises.Single(item => item.Id == id);
        }

        public IList<Pais> GetCollectionByCriteria(ICriteria<Pais> criteria)
        {
            return _dbContext.Paises.Where(criteria.Criteria).ToList();
        }
    }
}
