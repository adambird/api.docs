using System.Collections.Generic;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class Resource: Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<ResourceDoc> ResourceDocs { get; set; }

        public Resource()
        {
            //ResourceDocs = new List<ResourceDoc>();
        }
    }
}
