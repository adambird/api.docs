using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace api.docs.data
{
    public class TransactionCoordinator : ITransactionCoordinator
    {
        private ITransaction _transaction;

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void StartTransaction()
        {
            var session = ApiDocsDb.GetCurrentSession();
            _transaction = session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollBackTransaction()
        {
            _transaction.Rollback();
            _transaction = null;
        }
    }
}
