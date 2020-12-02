using ApiDomain.Entities;
using System.Collections.Generic;

namespace ApiDomain.Shared.Data
{
    /// <summary>
    /// Contrato que determina metodos para creación
    /// </summary>
    /// <typeparam name="T">Entidad base</typeparam>
    public interface ICreate<T> where T : BaseEntity
    {
        /// <summary>
        /// Crea un nuevo elemento
        /// </summary>
        /// <param name="entity">Entidad con datos</param>
        T Create(T entity);
        /// <summary>
        /// Crea un nuevo conjunto de elementos
        /// </summary>
        /// <param name="entityCollection">Colección de entidades con datos</param>
        void Create(List<T> entityCollection);
    }
}
