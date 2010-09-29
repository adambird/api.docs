using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Common;
using api.docs.data.Map;

namespace api.docs.data
{
    public class ApiDocsContext : DbContext
    {
        static ApiDocsContext()
        {
            Database.SetInitializer<ApiDocsContext>(null);
        }

        public ApiDocsContext()
            : this(new SqlConnection(ConfigurationManager.ConnectionStrings["api.docs.data"].ConnectionString))
        { }

        public ApiDocsContext(DbConnection connection)
            : base(connection)
        { }

        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ResourceMap());
            modelBuilder.Configurations.Add(new ResourceDocMap());
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceDoc> ResourceDocs { get; set; }
    }
}
