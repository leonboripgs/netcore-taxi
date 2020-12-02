using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Repositories;
using ApiDomain.Shared.Data;
using ApiInfraestructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiInfraestructure.Data.Repositories
{
    /// <summary>
    /// Repositorio de datos de la entidad Usuario
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PostgresDbContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        public UsuarioRepository(PostgresDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        public Usuario Create(Usuario entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Create(List<Usuario> entityCollection)
        {
            _context.AddRange(entityCollection);
        }
        /// <summary>
        /// Obtiene un Usuario por su identificador
        /// </summary>
        /// <param name="id">Identificador de usuario</param>
        /// <returns>Usuario</returns>
        public Usuario GetById(int id)
        {
            return _context.Usuarios.Single(item => item.Id == id);
        }
        public Usuario GetById(string id)
        {
            throw new NotImplementedException();
        }
        public Usuario GetByCriteria(ICriteria<Usuario> criteria)
        {
            return _context.Usuarios.FirstOrDefault(criteria.Criteria);
        }
        public IList<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }
        public IList<Usuario> GetCollectionByCriteria(ICriteria<Usuario> criteria)
        {
            return _context.Usuarios.Where(criteria.Criteria).ToList();
        }
        public void Update(Usuario entity)
        {
            _context.Update(entity);
        }

        public void Update(List<Usuario> entityCollection)
        {
            _context.UpdateRange(entityCollection);
        }
        public void Delete(Usuario entity)
        {
            _context.Remove(entity);
        }

        public void Delete(List<Usuario> entityCollection)
        {
            _context.RemoveRange(entityCollection);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}