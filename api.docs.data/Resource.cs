using System.Collections.Generic;
using api.docs.data.Repository;

namespace api.docs.data
{
    public class Resource: Entity
    {
        public virtual string Name { get; set; }

        private ICollection<ResourceDoc> _resourceDocs = new List<ResourceDoc>();
        public virtual IList<Field> Fields { get; set; }

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

        //public virtual IList<Field> Fields
        //{
        //    get { return _fields; }
        //    set
        //    {
        //        _fields = value;
        //        foreach (var field in _fields)
        //        {
        //            field.Resource = this;
        //        }
        //    }
        //}
    }
}
