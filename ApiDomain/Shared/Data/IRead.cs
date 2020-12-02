using ApiDomain.Entities;
using System.Collections.Generic;

namespace ApiDomain.Shared.Data
{
    public interface IRead<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetById(string id);
        T GetByCriteria(ICriteria<T> criteria);
        IList<T> GetAll();
        IList<T> GetCollectionByCriteria(ICriteria<T> criteria);
    }
}
