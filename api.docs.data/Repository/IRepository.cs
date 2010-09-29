using System;
using System.Collections.Generic;

namespace api.docs.data.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class, IModel, new()
    {
        T GetById(int id);
        void SaveOrUpdate(T model);
        void Add(T model);
        void SaveChanges();
        void Delete(T model);
        void DeleteById(int id);
        IList<T> GetAll();
        IList<T> GetList(QueryBase<T> query);
        T FindSingle(Func<T, bool> predicate);
        IList<T> Find(Func<T, bool> predicate);
    }
}
