using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    public class EntidadRepository : IEntidadRepository
    {
        private readonly PostgresDbContext _dbContext;
        public EntidadRepository(PostgresDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IList<Entidad> GetAll()
        {
            return _dbContext.Entidades.ToList();
        }

        public Entidad GetByCriteria(ICriteria<Entidad> criteria)
        {
            return _dbContext.Entidades.Single(criteria.Criteria);
        }

        public Entidad GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Entidad GetById(string id)
        {
            return _dbContext.Entidades.Single(item => item.Id == id);
        }

        public IList<Entidad> GetCollectionByCriteria(ICriteria<Entidad> criteria)
        {
            return _dbContext.Entidades.Where(criteria.Criteria).ToList();
        }
    }
}
