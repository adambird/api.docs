using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;

namespace api.docs.data.Map
{
    internal class ResourceMap : EntityConfiguration<Resource>
    {
        public ResourceMap()
        {
            this.HasKey(r => r.Id);

            this.MapSingleType(
                r => new {Id = r.Id, Name = r.Name}
                ).ToTable("Resources");

            this.HasMany(r => r.ResourceDocs).WithRequired().HasConstraint((rd, r) => rd.ResourceId == r.Id);
        }
    }
}
