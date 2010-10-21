using System.Collections.Generic;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class Resource: Entity
    {
        public virtual string Name { get; set; }

        private ICollection<ResourceDoc> _resourceDocs;

        public virtual ICollection<ResourceDoc> ResourceDocs
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
    }
}
