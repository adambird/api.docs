using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace api.docs.data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : Entity, new()
    {
        private ISession _session;

        protected Repository()
        {
        }   

        public void Dispose()
        {
            if (_session != null) _session.Dispose();
            _session = null;
        }

        private ISession GetSession()
        {
            if (_session == null)
            {
                _session = ApiDocsDb.SessionFactory.OpenSession();
            }
            return _session;
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
