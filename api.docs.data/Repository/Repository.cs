using System;
using System.Collections.Generic;
using System.Linq;

namespace api.docs.data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        protected readonly ApiDocsContext Context;

        protected Repository()
        {
            Context = new ApiDocsContext();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(T model)
        {
            throw new NotImplementedException();
        }

        public void Add(T model)
        {
            Context.Set<T>().Add(model);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Delete(T model)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IList<T> GetList(QueryBase<T> query)
        {
            throw new NotImplementedException();
        }

        public T FindSingle(Func<T, bool> predicate)
        {
            return Context.Set<T>().SingleOrDefault(predicate);
        }

        public IList<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
