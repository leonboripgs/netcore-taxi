using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly PostgresDbContext _dbContext;
        public MunicipioRepository(PostgresDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IList<Municipio> GetAll()
        {
            return _dbContext.Municipios.ToList();
        }

        public Municipio GetByCriteria(ICriteria<Municipio> criteria)
        {
            return _dbContext.Municipios.Single(criteria.Criteria);
        }

        public Municipio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Municipio GetById(string id)
        {
            return _dbContext.Municipios.Single(item => item.Id == id);
        }

        public IList<Municipio> GetCollectionByCriteria(ICriteria<Municipio> criteria)
        {
            return _dbContext.Municipios.Where(criteria.Criteria).ToList();
        }
    }
}
