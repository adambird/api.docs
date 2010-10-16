using System.Collections.Generic;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class Resource: Entity
    {
        public virtual string Name { get; set; }

        private IList<ResourceDoc> _resourceDocs;

        public virtual IList<ResourceDoc> ResourceDocs
        {
            get { return _resourceDocs; }
            set
            {
                _resourceDocs = value;
                foreach (var doc in _resourceDocs)
                {
                    doc.Resource = this;
                }
            }
        }

        public Resource()
        {
            //ResourceDocs = new List<ResourceDoc>();
        }
    }
}
