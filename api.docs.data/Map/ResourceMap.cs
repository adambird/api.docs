using System.Data.Entity.ModelConfiguration;

namespace api.docs.data.Map
{
    internal class ResourceMap : EntityConfiguration<Resource>
    {
        public ResourceMap()
        {
            this.MapSingleType(
                r => new {Id = r.Id, Name = r.Name}
                ).ToTable("Resource");

        }
    }
}
