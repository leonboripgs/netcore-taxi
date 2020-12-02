using ApiDomain.Entities;
using System.Collections.Generic;

namespace ApiDomain.Shared.Data
{
    public interface IDelete<T> where T : BaseEntity
    {
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        void Delete(T entity);
        /// <summary>
        /// Crea un nuevo conjunto de elementos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        void Delete(List<T> entityCollection);
    }
}