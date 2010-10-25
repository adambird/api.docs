using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.docs.data
{
    public interface ITransactionCoordinator : IDisposable
    {
        void StartTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
