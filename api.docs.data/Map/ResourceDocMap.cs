using System.Data.Entity.ModelConfiguration;

namespace api.docs.data.Map
{
    internal class ResourceDocMap : EntityConfiguration<ResourceDoc>
    {
        public ResourceDocMap()
        {
            this.MapSingleType(
                rd => new
                          {
                              Id = rd.Id,
                              ResourceId = rd.ResourceId,
                              Language = rd.Language,
                              Region = rd.Region,
                              Summary = rd.Summary
                          }
                ).ToTable("Resource_Docs");

            this.HasKey(rd => rd.Id);
        }
    }
}
