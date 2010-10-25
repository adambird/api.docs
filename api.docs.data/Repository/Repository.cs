using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Context;
using NHibernate.Linq;

namespace api.docs.data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : Entity, new()
    {
        protected Repository()
        {
        }   

        public void Dispose()
        {

        }

        private ISession GetSession()
        {
            return ApiDocsDb.GetCurrentSession();
        }

        public T GetById(Guid id)
        {
            return FindSingle(t => t.Id == id);
        }

        public void Add(T model)
        {
            GetSession().Save(model);
        }

        public void Save(T model)
        {
            GetSession().SaveOrUpdate(model);
        }

        public void SaveChanges()
        {
            GetSession().Flush();
        }

        public void Delete(T model)
        {
            GetSession().Delete(model);
        }

        public void DeleteById(Guid id)
        {
            Delete(GetById(id));
        }

        public IList<T> GetAll()
        {
            return GetSession().Query<T>().ToList();
        }

        public IList<T> GetList(QueryBase<T> query)
        {
            throw new NotImplementedException();
        }

        public T FindSingle(Func<T, bool> predicate)
        {
            return GetSession().Query<T>().SingleOrDefault(predicate);
        }

        public IList<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
