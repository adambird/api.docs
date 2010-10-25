using System;
using System.Reflection;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Context;
using NHibernate.Dialect;

namespace api.docs.data
{
    public class ApiDocsDb : IDisposable
    {
        public static ISessionFactory SessionFactory {get; protected set; }

        static ApiDocsDb()
        {
            Initialise();
        }

        private static void Initialise()
        {
            Initialise(System.Configuration.ConfigurationManager.ConnectionStrings["api.docs.data"].ConnectionString);
        }

        public static void Initialise(string connectionString)
        {
            log4net.Config.XmlConfigurator.Configure();

            var nhConfig = new NHibernate.Cfg.Configuration()
                .CurrentSessionContext<CallSessionContext>()
                .Proxy(proxy => proxy.ProxyFactoryFactory<ProxyFactoryFactory>())
                .DataBaseIntegration(db =>
                                         {
                                             db.Dialect<MsSql2008Dialect>();
                                             db.ConnectionString = connectionString;
                                             db.BatchSize = 100;
                                         })
                .AddAssembly(Assembly.GetExecutingAssembly());

            SessionFactory = nhConfig.BuildSessionFactory();

        }

        public void Dispose()
        {
        }

        public static ISession GetCurrentSession()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
            {
                return SessionFactory.GetCurrentSession();
            }
            else
            {
                var session = SessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
                return session;
            }

        }

    }
}
