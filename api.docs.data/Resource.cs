using System.Collections.Generic;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class Resource: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ResourceDoc> ResourceDocs { get; set; }

        public Resource()
        {
            ResourceDocs = new List<ResourceDoc>();
        }
    }
}
