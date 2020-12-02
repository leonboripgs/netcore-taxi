using ApiDomain.Entities;
using System.Collections.Generic;

namespace ApiDomain.Shared.Data
{
    public interface IUpdate<T> where T : BaseEntity
    {
        /// <summary>
        /// Actualiza un element existente
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        void Update(T entity);
        /// <summary>
        /// Actualiza un conjunto de elementos existentes
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        void Update(List<T> entityCollection);
    }
}
