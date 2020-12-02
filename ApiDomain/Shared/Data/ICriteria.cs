using System;
using System.Linq.Expressions;

namespace ApiDomain.Shared.Data
{
    /// <summary>
    /// Patrón especificación
    /// </summary>
    /// <typeparam name="T">Tipo de objeto</typeparam>
    public interface ICriteria<T>
    {
        /// <summary>
        /// Criterios
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }
    }
}
