using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.docs.data
{
    public class Field : Entity
    {
        public virtual string Name { get; set; }
        public virtual string FieldType { get; set; }

        public virtual Resource Resource { get; set; }

        private ICollection<FieldDoc> _fieldDocs = new List<FieldDoc>();

        public virtual ICollection<FieldDoc> FieldDocs
        {
            get { return _fieldDocs; }
            set
            {
                _fieldDocs = value;
                foreach (var doc in _fieldDocs)
                {
                    doc.Field = this;
                }
            }
        }
    }
}
