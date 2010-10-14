using System;
using System.Collections.Generic;

namespace api.docs.data.Repository
{
    public interface IRepository<T> : IDisposable
        where T : Entity, new()
    {
        T GetById(Guid id);
        void Add(T model);
        void Save(T model);
        void SaveChanges();
        void Delete(T model);
        void DeleteById(Guid id);
        IList<T> GetAll();
        IList<T> GetList(QueryBase<T> query);
        T FindSingle(Func<T, bool> predicate);
        IList<T> Find(Func<T, bool> predicate);
    }
}
